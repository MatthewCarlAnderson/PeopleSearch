import { TestBed, inject } from '@angular/core/testing';

import { PeopleSearchService } from './people-search.service';
import {HttpClientTestingModule} from '@angular/common/http/testing';

describe('PeopleSearchService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PeopleSearchService]
    });
  });

  it('should be created', inject([PeopleSearchService], (service: PeopleSearchService) => {
    expect(service).toBeTruthy();
  }));
});
