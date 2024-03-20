import { Component } from '@angular/core';
import { TextSourceService } from '../services/text-source.service';
import { TextSourceResult } from './text-source-result';
import { finalize, tap } from 'rxjs/operators';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  searchMask: string = '35B17';
  textSources: TextSourceResult[] = [];
  loading = false;

  constructor(private textSourceService: TextSourceService) { }

  onSearch(): void {
    this.textSourceService
      .getTextSources(this.searchMask)
      .pipe(
        tap(() => this.loading = true),
        finalize(() => this.loading = false))
      .subscribe(data => {
        this.textSources = data;
    });
  }

  onStop(): void {
    this.textSourceService.stop();
    this.loading = false;
  }
}
