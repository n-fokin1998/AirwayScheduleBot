import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [LayoutComponent],
  imports: [
    SharedModule,
    RouterModule
  ],
  exports: [LayoutComponent]
})
export class LayoutModule { }
