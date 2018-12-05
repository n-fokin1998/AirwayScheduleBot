import { Component, OnInit } from '@angular/core';
import { PlanesService } from '../../services/planes.service';
import { Plane } from '../../interfaces/plane.model';

@Component({
  selector: 'app-planes',
  templateUrl: './planes.component.html',
  styleUrls: ['./planes.component.css'],
  providers: [PlanesService]
})
export class PlanesComponent implements OnInit {
  constructor(private planesService: PlanesService) { }

  public planesList: Plane[]; 

  ngOnInit() {
    this.planesService.getPlanes().subscribe(data => {
      this.planesList = data;
    });
  }
}
