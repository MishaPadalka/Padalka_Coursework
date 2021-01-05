import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, Subject } from 'rxjs';
import { TrainsService } from 'src/app/Services/trains.service';
import { takeUntil } from 'rxjs/operators';
import { FullTrain } from 'src/app/Models/Trains/FullTrain';
import { Seat } from 'src/app/Models/Seats/Seat';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CarriageService } from 'src/app/Services/carriage.service';
import { NewCarriage } from 'src/app/Models/Carriages/NewCarriage';
import { NewOrder } from 'src/app/Models/Orders/NewOrder';
import { OrdersService } from 'src/app/Services/orders.service';
import { Carriage } from 'src/app/Models/Carriages/Carriage';

declare var $: any;

@Component({
  selector: 'app-full-train',
  templateUrl: './full-train.component.html',
  styleUrls: ['./full-train.component.sass']
})
export class FullTrainComponent implements OnInit, OnDestroy {

  train: FullTrain;
  sending = false;
  sendingSeat = false;
  loading = true;
  unsubscribe = new Subject();
  id;
  openedSeatId = -1;
  seatIdCreating = -1;
  openedId = -1;
  Form: FormGroup;
  SeatForm: FormGroup;
  private subscription: Subscription;
  constructor(
    private activateRoute: ActivatedRoute,
    private trainService: TrainsService,
    private carriageService: CarriageService,
    private router: Router,
    private orderService: OrdersService
  ) {
    this.subscription = activateRoute.params.subscribe(
      params => (this.id = params.id)
    );
    this.Form = new FormGroup({
      type: new FormControl('', Validators.required),
      number: new FormControl('', [Validators.required]),
      seatPrice : new FormControl('', [Validators.required])
    });
    this.SeatForm = new FormGroup(
      {
        buyerFirstName: new FormControl('', Validators.required),
        buyerLastName: new FormControl('', Validators.required),
      }
    );
  }
  check(seat: Seat, idCarriage: number) {
    this.SeatForm.reset();
    if (seat.free === false) {
      return;
    }
    this.seatIdCreating  = seat.id;
    this.openedSeatId = seat.numberSeat;
    if (this.openedId === idCarriage) {
      return;
    } else {
      $(`#${this.openedId}`).hide();
      $(`#${idCarriage}`).slideDown('fast');
      this.openedId = idCarriage;
    }
  }
  createCarriage() {
    this.sending = true;
    const formValue = this.Form.value;
    const carriage: NewCarriage = {
      trainId: this.train.id,
      countSeats: formValue.number,
      type: formValue.type,
      price: formValue.seatPrice
    };
    this.carriageService.addCarriage(carriage).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => {this.train.carriages.push(x); this.sending = false; this.back(); this.Form.reset(); }, error => console.log(error));
  }
  createOrder($price, carriage: Carriage) {

    this.sendingSeat = true;
    const formValue = this.SeatForm.value;
    const newOrder: NewOrder = {
      seatId: this.seatIdCreating,
      price: $price,
      buyerFirstName: formValue.buyerFirstName,
      buyerLastName: formValue.buyerLastName
    };
    this.orderService.createOrder(newOrder).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => {
      this.sendingSeat = false;
      const seats = carriage.seats.map((g) => { if (g.id === this.seatIdCreating) {g.free = false; } return g; });
      carriage.seats = seats;
      this.backSeat();
      --this.train.freePlaces;
      ++this.train.occupiedPlaces;
      this.SeatForm.reset();
    }
      , error =>  { this.sendingSeat = false; console.log(error); });
  }
  backSeat() {
    $(`#${this.openedId}`).hide();
    this.openedId = -1;
  }
  deleteTrain() {
    this.trainService.deleteTrain(this.id).pipe(takeUntil(this.unsubscribe)).subscribe(x => this.router.navigate(['/trains'])
    , error => console.log(error));
  }
  deleteCarriage(id: number) {
    this.carriageService.deleteCarriage(id).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => { this.train.carriages = this.train.carriages.filter(g => g.id !== id); }, error => console.log(error));
  }
  createNew() {
    if (
      $('.create')
        .is(':hidden')
    ) {
      $('.create').slideDown('fast');
    } else {
      $('.create').hide();
    }
  }
  back() {
    $('.create').hide();
  }
  percent($seats: Seat[]) {
    if ($seats.length === 0) {
      return 0;
     }
    const percent  = $seats.filter(x => x.free === false).length / $seats.length;
    return (Number(percent) * 100).toFixed(2);
  }
  checkFreeSpace($carriage: Seat[]) {
    const count = $carriage.filter(x => x.free === false);
    return count.length !== 0;
  }
  ngOnInit() {
    this.trainService
      .getTrain(this.id)
      .pipe(takeUntil(this.unsubscribe))
      .subscribe(
        x => {
          this.train = x.body;
          this.loading = false;
        },
        error => console.log(error)
      );
  }
  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.unsubscribe();
  }
}
