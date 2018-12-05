import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home.component';
import { Router, RouterModule } from '@angular/router';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent }
    ])
  ],
  declarations: [HomeComponent]
})
export class HomeModule { }
