import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodoEntriesComponent } from './todo-entries.component';

describe('TodoEntriesComponent', () => {
  let component: TodoEntriesComponent;
  let fixture: ComponentFixture<TodoEntriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TodoEntriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TodoEntriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
