import { Component, OnInit } from '@angular/core';
import { PeopleSearchService } from './people-search.service';
import { FormControl } from '@angular/forms';
import {switchMap, debounceTime, distinctUntilChanged, catchError, tap, delay} from 'rxjs/operators';
import { Person } from './person';
import {of} from 'rxjs/observable/of';
import {DomSanitizer} from '@angular/platform-browser';


@Component({
  selector: 'app-people-search',
  templateUrl: './people-search.component.html',
  styleUrls: ['./people-search.component.css']
})
export class PeopleSearchComponent implements OnInit {

  public initted = true;
  public done = true;
  public search = new FormControl();
  public people: Array<Person> = [];

  constructor(private peopleSearchService: PeopleSearchService, private sanitizer: DomSanitizer) { }

  ngOnInit() {

    // this.search.valueChanges
    //   .subscribe(value => {
    //     this.peopleSearchService.getMatch(value).subscribe(results => {
    //       this.people = results;
    //     })
    //   });

    this.search.valueChanges.pipe(
     tap(val => {this.done = false; this.initted = false; }),
     debounceTime(400),
     delay(1500),
     distinctUntilChanged(),
     switchMap(value => this.peopleSearchService.getMatch(value).pipe(
       catchError(error => of([])))
     )
    ).subscribe(results => {
      this.done = true;
      this.people = results;
    });
  }

  onKeyDown($event: KeyboardEvent) {
      console.log('event', $event);
      this.done = false;
      return($event);
  }

  getImage(imageText: string) {
    console.log(imageText);
    return this.sanitizer.bypassSecurityTrustUrl(imageText);
  }
}
