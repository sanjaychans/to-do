import { Component, OnInit } from '@angular/core';
import { ToDoService } from '../to-do.service';
import { MatTableDataSource } from '@angular/material/table';
import { todoEntry } from '../interfaces/todoentry';
import { lookupHelper } from '../helpers/lookupHelper';
import { MatDialog } from '@angular/material';
import { EditEntryComponent } from '../edit-entry/edit-entry.component';


@Component({
  selector: 'app-todo-entries',
  templateUrl: './todo-entries.component.html',
  styleUrls: ['./todo-entries.component.css']
})
export class TodoEntriesComponent implements OnInit {

  displayedColumns: string[] = ['subject', 'startDate', 'dueDate', 'status', 'priority', 'percentageCompleted', 'actions'];
  dataSource;
  lookups;
  dialogRef;

  constructor(private service: ToDoService,
    private luHelper: lookupHelper,
    private dialog: MatDialog) { }

  ngOnInit() {

    this.loadEntries();
    this.lookups = this.luHelper.getAll();
    
  }

  loadEntries() {
    this.service.getTodoEntries().subscribe((data) => {
      console.log('Result - ', data);
      this.dataSource = new MatTableDataSource<todoEntry>(data as todoEntry[]);
    });
  }

  getLookupName(code: string) {
    return this.luHelper.getLookupName(code);
  }

  updateEntry(entry) {
    console.log('Entry -', entry);
    this.dialogRef = this.dialog.open(EditEntryComponent, {
      data: {
        id: entry.id,
        subject: entry.subject,
        startDate: entry.startDate,
        dueDate: entry.dueDate,
        status: entry.status,
        priority: entry.priority,
        percentageCompleted: entry.percentageCompleted
      }
    })

    this.dialogRef.afterClosed().subscribe((result) => {
      this.loadEntries();
      this.dialogRef = null;
    })
    
  }

}
