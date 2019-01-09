import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from './layout/layout.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    LayoutModule,
    RouterModule.forRoot([
      { 
        path: 'planes',
        component: LayoutComponent,
        children: [
          { 
            path: '', 
            loadChildren: './planes/planes.module#PlanesModule',
            pathMatch: 'full' 
          },
        ]
      },
      { 
        path: '',
        component: LayoutComponent,
        children: [
          { 
            path: '', 
            loadChildren: 'app/home/home.module#HomeModule',
            pathMatch: 'full' 
          },
        ]
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
