import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

///Base class for service requests
@Injectable({
  providedIn: 'root'
})
export class ServiceBase {

  constructor(private http : HttpClient, private baseUrl : string) { }

  //make get request
  makeGetRequest<T>(endpoint: string) {
    return this.http.get<T>(this.baseUrl + endpoint)
      .pipe(catchError(this.handleError));
  }

  //make post request
  makePostRequest(endpoint, data) {
    return this.http.post(this.baseUrl + endpoint, data)
      .pipe(catchError(this.handleError));
  }

  //error handler
  handleError(error: HttpErrorResponse) {
    alert(error.error.error);
    return throwError(error);
  }
}
