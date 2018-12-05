import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Plane } from '../interfaces/plane.model';
import { planesLink } from '../shared/api-links';
import { PlaneResponse } from '../interfaces/response.model';

@Injectable({
  providedIn: 'root'
})
export class PlanesService {
  constructor(private httpClient: HttpClient) {}

  public getPlanes(): Observable<Plane[]> {
    return this.httpClient
      .get<PlaneResponse>(planesLink)
      .pipe(
        map(data => { return data.items; }), 
        catchError(e => { return of(e); }));
  }
}
