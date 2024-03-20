import { Injectable } from '@angular/core';
import { Observable, Subject, of, throwError } from 'rxjs';
import { catchError, map, scan, takeUntil } from 'rxjs/operators';
import { StreamProcessor } from '../../../enhancements/stream-processor';
import { TextSourceResult } from '../search/text-source-result';
import { RequestResult } from '../../../enhancements/request-result';

@Injectable({
  providedIn: 'root'
})
export class TextSourceService {
  private searchUrl = 'http://localhost:54414/TextSource/Search';
  private stopSource = new Subject<void>();
  constructor() { }

  getTextSources(mask: string): Observable<TextSourceResult[]> {
    let steamProcessor = new StreamProcessor();
    const url = `${this.searchUrl}?mask=${encodeURIComponent(mask)}`;
    return steamProcessor
      .fetchStream<RequestResult<TextSourceResult>>(url)
      .pipe(
        takeUntil(this.stopSource),
        catchError(error => {
          if (error.messageType !== 'Success') {
            return throwError(() => new Error(error.messageText));
          }
          return of(error);
        }),
        map(item => item.data),
        scan((all, item) => [...all, item], [] as TextSourceResult[]),
      );
  }
  
  stop() {
    this.stopSource.next();
  }
}
