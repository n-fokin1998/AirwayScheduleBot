import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { planesLink } from '../shared/api-links';
import { PlaneResponse } from '../interfaces/response.model';
import { ParamMap } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class PlanesService {
  constructor(private httpClient: HttpClient) {}

  public getPlanes(params:ParamMap): Observable<PlaneResponse> {
    const httpParams = this.generateHttpParams(params);

    return this.httpClient
      .get<PlaneResponse>(planesLink, { params: httpParams })
      .pipe(
        catchError(e => { return of(e); }));
  }

  private generateHttpParams(params:ParamMap): HttpParams {
    let resultParams: HttpParams = new HttpParams();

    params.keys.forEach(key => {
      const value = params.get(key);

      if(value && typeof value === 'string') {
        resultParams = resultParams.set(key, value.trim())
      }
    });
    
    return resultParams;
  }
}
