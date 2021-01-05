import { Component, OnInit, OnDestroy } from '@angular/core';
import { TrainsService } from 'src/app/Services/trains.service';
import { Subject } from 'rxjs';
import { takeUntil, max } from 'rxjs/operators';
import { Train } from 'src/app/Models/Trains/Train';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { parse } from 'querystring';
import { NewTrain } from 'src/app/Models/Trains/NewTrain';
import { isNull } from 'util';

declare var $: any;

@Component({
  selector: 'app-trains-container',
  templateUrl: './trains-container.component.html',
  styleUrls: ['./trains-container.component.sass']
})
export class TrainsContainerComponent implements OnInit, OnDestroy {
  unsubscribe = new Subject();
  loading = true;
  trains: Train[];
  Form: FormGroup;
  word = '';
  arrival: Date = null;
  departure: Date = null;
  constructor(private trainService: TrainsService) {
    this.Form = new FormGroup({
      name: new FormControl('', Validators.required),
      whereGoes: new FormControl('', [Validators.required]),
      whereFrom: new FormControl('', Validators.required)
    });
  }
  submit() {
    this.arrival.setHours(this.arrival.getHours() + 2);
    this.departure.setHours(this.departure.getHours() + 2);
    const formValue = this.Form.value;
    const train: NewTrain = {
      name: formValue.name,
      whereFrom: formValue.whereFrom,
      whereGoes: formValue.whereGoes,
      arrival: this.arrival,
      departure: this.departure
    };
    this.trainService.addTrain(train).pipe(takeUntil(this.unsubscribe)).subscribe(x => this.trains.unshift(x), error => console.log(error));
    this.Form.markAsPristine();
    this.Form.markAsUntouched();
    this.Form.reset();
    this.arrival = null;
    this.departure = null;
    $('.create').hide();
  }
  getDate(d: Date): Date {
    return new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), d.getHours(), d.getMinutes()));
  }
  setDeparture($event) {
    if (!isNaN(Date.parse($event))) {
      this.departure = new Date($event);

    } else {
      this.departure = undefined;
    }
  }

  setArrival($event) {
    if (!isNaN(Date.parse($event))) {
      this.arrival = new Date($event);

    } else {
      this.arrival = undefined;
    }
  }
  onChange() {
    if (this.word === '' || this.word === null) {
      this.trainService
      .getAllTrains()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        x => {
          this.trains = x.body.reverse();
          this.loading = false;
        },
        error => console.log(error)
      );
      return;
    }
    this.trainService.searchTrain(this.word).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => this.trains = x.body, error => console.log(error));
  }
  Check(typesPlace) {
    if (!isNull(typesPlace)) {
    return Object.keys(typesPlace).length !== 0;
    }
    return false;
  }
  ngOnInit() {
    $('.ui.calendar').calendar({
      popupOptions: {
        observeChanges: false
      }
    });
    this.trainService
      .getAllTrains()
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        x => {
          this.trains = x.body.reverse();
          this.loading = false;
        },
        error => console.log(error)
      );
  }
  create() {
    if (
      $('.create')
        .is(':hidden')
    ) {
      $('.create').slideDown('fast');
    } else {
      $('.create').hide();
    }
  }
  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.unsubscribe();
  }
}
