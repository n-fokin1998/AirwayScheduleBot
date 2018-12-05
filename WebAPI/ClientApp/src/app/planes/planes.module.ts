import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { PlanesComponent } from './planes-list/planes.component';
import { PlanesRoutingModule } from './planes-routing.module';

@NgModule({
  imports: [
    SharedModule,
    PlanesRoutingModule
  ],
  declarations: [PlanesComponent]
})
export class PlanesModule { }
