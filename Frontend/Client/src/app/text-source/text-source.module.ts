import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TextSourceRoutingModule } from './text-source-routing.module';
import { SearchComponent } from './search/search.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SearchComponent
  ],
  imports: [
    CommonModule,
    TextSourceRoutingModule,
    FormsModule
  ]
})
export class TextSourceModule { }
