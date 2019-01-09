import { Component, OnInit } from '@angular/core';
import { PlanesService } from '../../services/planes.service';
import { Plane } from '../../interfaces/plane.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-planes',
  templateUrl: './planes.component.html',
  styleUrls: ['./planes.component.css'],
  providers: [PlanesService]
})
export class PlanesComponent implements OnInit {
  constructor(
    private planesService: PlanesService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) { }

  public planesList: Plane[];
  public totalItems: number;
  public searchKey: string;
  public httpParams: object;
  public page: number = 1;

  ngOnInit() {
    this.setQueryParamsListener();
  }

  applySearch() {
    const params = { queryParams: { searchKey: this.searchKey } };
    this.router.navigate(['planes'], params);
  }

  applyPagination(page: number) {
    const params = { queryParams: { page: page } };
    this.router.navigate(['planes'], params);
  }

  setQueryParamsListener() {
    this.activatedRoute.queryParamMap.subscribe(params => {
      this.planesService.getPlanes(params).subscribe(data => {
        this.planesList = data.items;
        this.totalItems = data.totalCount
      });
    });
  }
}
