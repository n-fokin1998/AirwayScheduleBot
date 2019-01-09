import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PagerComponent } from './pagination/pager.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap' ;

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    NgbModule
  ],
  declarations: [PagerComponent]
})
export class SharedModule { }
