import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { OrdersService } from 'src/app/Services/orders.service';
import { takeUntil, take } from 'rxjs/operators';
import { Order } from 'src/app/Models/Orders/Orders';

declare var $: any;


@Component({
  selector: 'app-orders-container',
  templateUrl: './orders-container.component.html',
  styleUrls: ['./orders-container.component.sass']
})
export class OrdersContainerComponent implements OnInit, OnDestroy {

  orders: Order[];
  time: Date = null;
  unsubscribe = new Subject();
  searchDate;
  constructor(private orderService: OrdersService) { }

  Search($event: Date) {
    if (!$event) {
      return;
    }
    const date = this.getDate($event);
    this.searchDate = date;
    this.orderService.search(date).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => this.orders = x.body, error => console.log(error));
  }
  ngOnInit() {
    $('.ui.calendar').calendar({
      popupOptions: {
        observeChanges: false
      },
      type: 'date',
      onChange: (date, text) => this.Search(date),
    });
    this.orderService.getAll().pipe(takeUntil(this.unsubscribe))
    .subscribe(x => {this.orders = x.body; }, error => console.log(error));
  }
  getSearch() {
    if (this.searchDate) {
      return false;
    }
    return true;
  }
  clear() {
    $('.ui.calendar').calendar('clear');
    this.searchDate = undefined;
    this.orderService.getAll().pipe(takeUntil(this.unsubscribe))
    .subscribe(x => {this.orders = x.body; }, error => console.log(error));
  }
  getDate(d: Date): Date {
    return new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate()));
  }
  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.unsubscribe();
  }
}
