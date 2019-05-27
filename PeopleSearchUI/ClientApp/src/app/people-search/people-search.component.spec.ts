import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PeopleSearchComponent } from './people-search.component';
import {ReactiveFormsModule} from '@angular/forms';
import {PeopleSearchService} from './people-search.service';
import {HttpClient} from '@angular/common/http';
import {PeopleSearchServiceMock} from './people-search-service-mock';

describe('PeopleSearchComponent', () => {
  let component: PeopleSearchComponent;
  let fixture: ComponentFixture<PeopleSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PeopleSearchComponent ],
      imports: [ReactiveFormsModule],
      providers: [
        {provide: PeopleSearchService, useClass: PeopleSearchServiceMock }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PeopleSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

