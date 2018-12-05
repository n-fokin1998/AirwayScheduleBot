import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { PlanesModule } from './planes/planes.module';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [AppComponent, LayoutComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HomeModule,
    PlanesModule,
    RouterModule.forRoot([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
