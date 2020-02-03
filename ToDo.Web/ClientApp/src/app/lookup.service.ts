import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lookupItem } from './interfaces/lookupItem';
import { ServiceBase } from './service-base.service';

@Injectable({
  providedIn: 'root'
})

//service component for lookup data
export class LookupService extends ServiceBase  {

  constructor(http: HttpClient, @Inject('API_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  //service call for lookup for a tag
  fetchLookup(tag?: string) {
    return this.makeGetRequest<lookupItem[]>(`lookup/${tag}`);
  }

  //service call for all lookup data
  fetchAllLookups() {
    return this.makeGetRequest<lookupItem[]>(`lookup`);

  }
}
