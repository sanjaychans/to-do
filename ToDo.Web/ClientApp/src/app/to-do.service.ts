import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { todoEntry } from './interfaces/todoentry';


@Injectable({
  providedIn: 'root'
})
export class ToDoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTodoEntries() {
    return this.http.get<todoEntry[]>(this.baseUrl + 'todo/all');
  }

  createEntry(entry) {
    return this.http.post(this.baseUrl + 'todo', entry);
  }
}
