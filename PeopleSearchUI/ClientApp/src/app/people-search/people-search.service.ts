import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs/Observable';
import { Person } from './person';
import 'rxjs/add/operator/map';

@Injectable()
export class PeopleSearchService {
  private BASE_URL = environment.base_url + 'api';
  constructor(private http: HttpClient) { }

  getValues() {
    return this.http.get( this.BASE_URL +  '/values');
  }

  getPeople() {
    return this.http.get(this.BASE_URL + '/people');
  }

  getMatch(search: string): Observable<Person[]> {
    // return this.http.get<any[]>(this.BASE_URL + '/people/' + search);
    return this.http.get<any[]>(this.BASE_URL + '/people/' + search)
      .map(response =>
        response.map(person => {
          return new Person(person);
        })); }

}
