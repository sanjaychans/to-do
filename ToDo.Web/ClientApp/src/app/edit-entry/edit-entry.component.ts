import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { lookupHelper } from '../helpers/lookupHelper';
import { ToDoService } from '../to-do.service';
import { TodoEntriesComponent } from '../todo-entries/todo-entries.component';


@Component({
  selector: 'app-edit-entry',
  templateUrl: './edit-entry.component.html',
  styleUrls: ['./edit-entry.component.css']
})

///Edit ToDo component
export class EditEntryComponent implements OnInit {

  form: FormGroup;
  id: number;
  statuses;
  priorities;

  constructor(private fb: FormBuilder,
    private lookupHelper: lookupHelper,
    private dialogRef: MatDialogRef<EditEntryComponent>,
    private service: ToDoService,
    @Inject(MAT_DIALOG_DATA) {
      subject, startDate, dueDate, status, priority, percentageCompleted, id
    }) {
    this.id = id;

    //initialize the form with data from the MAT DIALOG
    this.form = fb.group({
      id: [id],
      subject: [subject, Validators.required],
      startDate: [startDate, Validators.required],
      dueDate: [dueDate, Validators.required],
      status: [status, Validators.required],
      priority: [priority, Validators.required],
      percentageCompleted: [percentageCompleted, [Validators.required, Validators.pattern('\\d+\\.?\\d*')]]
    })
  }

  ngOnInit() {
    //initialize the lookup entries
    if (!this.statuses) {
      this.lookupHelper.getLookup('ST').then((val) => {
        this.statuses = val;
      });
    }

    if (!this.priorities) {
      this.lookupHelper.getLookup('PT').then((val) => {
        this.priorities = val;
      });
    }
  }

  close() {
    //close the dialog window
    this.dialogRef.close();
  }

  save() {
    //invoke ToDoService, save the entry and close the dialog window
    this.service.createOrUpdateEntry(this.form.value).subscribe((data) => {
      console.log(`Update return id - ${data}`);
      this.close();
    });

  }
}
