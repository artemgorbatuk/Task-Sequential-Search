import { Observable } from 'rxjs';
import { JsonStreamDecoder } from './json-stream-decoder';

/**
 * Stream server data (e.g. from endpoint returning IAsyncEnumerable)
 * @type T type of stream element
 * @param input input param of {@link fetch}
 * @param init init param of {@link fetch} (excluding abort signal)
 * @return stream of array elements one by one
 */

export class StreamProcessor {
  fetchStream<T>(input: RequestInfo, init?: RequestInit): Observable<T> {
    return new Observable<T>(observer => {
      const controller = new AbortController();
      fetch(input, { ...init, signal: controller.signal })
        .then(async response => {
          const reader = response.body?.getReader();
          if (!reader) {
            throw new Error('Failed to read response');
          }
          const decoder = new JsonStreamDecoder();
          while (true) {
            const { done, value } = await reader.read();
            if (done) break;
            if (!value) continue;

            decoder.decodeChunk<T>(value, item => observer.next(item));
          }
          observer.complete();
          reader.releaseLock();
        })
        .catch(err => observer.error(err));
      return () => controller.abort();
    });
  }
}
