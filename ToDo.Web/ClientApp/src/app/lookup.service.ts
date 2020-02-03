import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lookupItem } from './interfaces/lookupItem';

@Injectable({
  providedIn: 'root'
})

  //service component for lookup data
export class LookupService {
  
  constructor(private http: HttpClient, @Inject('API_URL') private baseUrl: string) { }

  //service call for lookup for a tag
  fetchLookup(tag?: string) {
    return this.http.get<lookupItem[]>(this.baseUrl + `lookup/${tag}`);
  }

  //service call for all lookup data
  fetchAllLookups() {
    return this.http.get<lookupItem[]>(this.baseUrl + `lookup`);
  }
}
