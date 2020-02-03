import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { todoEntry } from './interfaces/todoentry';
import { ServiceBase } from './service-base.service';


@Injectable({
  providedIn: 'root'
})

//service component for to-do data
export class ToDoService extends ServiceBase  {

  constructor(http: HttpClient, @Inject('API_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  //service call for all to-do entries
  getTodoEntries() {
    return this.makeGetRequest<todoEntry[]>('todo/all');
  }

  //service call to create or update a to-do entry
  createOrUpdateEntry(entry) {
    return this.makePostRequest('todo', entry);
  }

}
