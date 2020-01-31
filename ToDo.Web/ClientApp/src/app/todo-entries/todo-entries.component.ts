import { Component, OnInit } from '@angular/core';
import { ToDoService } from '../to-do.service';
import { MatTableDataSource } from '@angular/material/table';
import { todoEntry } from '../interfaces/todoentry';
import { lookupHelper } from '../helpers/lookupHelper';


@Component({
  selector: 'app-todo-entries',
  templateUrl: './todo-entries.component.html',
  styleUrls: ['./todo-entries.component.css']
})
export class TodoEntriesComponent implements OnInit {

  displayedColumns: string[] = ['subject', 'startDate', 'dueDate', 'status', 'priority', 'percentageCompleted'];
  dataSource;
  lookups;

  constructor(private service: ToDoService, private luHelper: lookupHelper) { }

  ngOnInit() {
    this.service.getTodoEntries().subscribe((data) => {
      console.log('Result - ', data);
      this.dataSource = new MatTableDataSource<todoEntry>(data as todoEntry[]);
    });

    this.lookups = this.luHelper.getAll();
  }

  getLookupName(code: string) {
    console.log(code);
    return this.luHelper.getLookupName(code);
  }



}
