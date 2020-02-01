import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

//components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoEntriesComponent } from './todo-entries/todo-entries.component';
import { NewEntryComponent } from './new-entry/new-entry.component';

//services
import { LookupService } from './lookup.service';
import { ToDoService } from './to-do.service';

//material design
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule, MatInputModule, MatDatepickerModule, MatCardModule, MatSelectModule, MatNativeDateModule, MatDialogModule } from '@angular/material';

//forms
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TodoEntriesComponent,
    NewEntryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: TodoEntriesComponent, pathMatch: 'full' },
      { path: 'new-entry', component: NewEntryComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    BrowserAnimationsModule, MatTableModule, ReactiveFormsModule, MatButtonModule, MatInputModule, MatDatepickerModule, MatCardModule, MatSelectModule, MatNativeDateModule, MatDialogModule
  ],
  providers: [LookupService, ToDoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
