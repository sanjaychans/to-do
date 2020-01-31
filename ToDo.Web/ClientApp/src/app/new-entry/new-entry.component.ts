import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { lookupHelper } from '../helpers/lookupHelper';
import { ToDoService } from '../to-do.service';


@Component({
  selector: 'app-new-entry',
  templateUrl: './new-entry.component.html',
  styleUrls: ['./new-entry.component.css']
})
export class NewEntryComponent implements OnInit {

  statuses;
  priorities;

  constructor(private lookupHelper: lookupHelper, private service: ToDoService) { }

  entryForm = new FormGroup({
    subject: new FormControl('', Validators.required),
    startDate: new FormControl('', Validators.required),
    dueDate: new FormControl('', Validators.required),
    status: new FormControl('', Validators.required),
    priority: new FormControl('', Validators.required),
    percentageCompleted: new FormControl('', [Validators.required, Validators.pattern('\\d+\\.?\\d*')])
  })

  ngOnInit() {
    this.lookupHelper.getLookup('ST').then((val) => {
      this.statuses = val;
    });
    this.lookupHelper.getLookup('PT').then((val) => {
      this.priorities = val;
    });
  }

  onSubmit() {
    console.log(this.entryForm.value);
    this.service.createEntry(this.entryForm.value).subscribe((data) => {
      console.log('Entry Saved - ', data);
    })
  }

}
