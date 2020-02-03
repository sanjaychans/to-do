import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { todoEntry } from './interfaces/todoentry';


@Injectable({
  providedIn: 'root'
})

//service component for to-do data
export class ToDoService {

  constructor(private http: HttpClient, @Inject('API_URL') private baseUrl: string) { }

  //service call for all to-do entries
  getTodoEntries() {
    return this.http.get<todoEntry[]>(this.baseUrl + 'todo/all');
  }

  //service call to create or update a to-do entry
  createOrUpdateEntry(entry) {
    return this.http.post(this.baseUrl + 'todo', entry);
  }

}
