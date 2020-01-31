import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lookupItem } from './interfaces/lookupItem';

@Injectable({
  providedIn: 'root'
})
export class LookupService {
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  fetchLookup(tag?: string) {
    return this.http.get<lookupItem[]>(this.baseUrl + `lookup/${tag}`);
  }

  fetchAllLookups() {
    return this.http.get<lookupItem[]>(this.baseUrl + `lookup`);
  }
}
