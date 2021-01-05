import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, Subject } from 'rxjs';
import { OrdersService } from 'src/app/Services/orders.service';
import { takeUntil } from 'rxjs/operators';
import { Order } from 'src/app/Models/Orders/Orders';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UpdateOrder } from 'src/app/Models/Orders/UpdateOrders';

@Component({
  selector: 'app-full-order',
  templateUrl: './full-order.component.html',
  styleUrls: ['./full-order.component.sass']
})
export class FullOrderComponent implements OnInit, OnDestroy {

  Form: FormGroup;
  update = false;
  order: Order;
  sending = false;
  unsubscribe = new Subject();
  id;
  loading = true;
  private subscription: Subscription;

  constructor(private activateRoute: ActivatedRoute, private orderService: OrdersService, private router: Router) {
    this.subscription = activateRoute.params.subscribe(
      params => (this.id = params.id));
    this.Form = new FormGroup({
        firstName: new FormControl('', Validators.required),
        secondName: new FormControl('', [Validators.required]),
      });
  }

  ngOnInit() {
    this.orderService.getById(this.id).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => {this.order = x.body, this.loading = false; }, error => console.log(error));
  }
  Back() {
    this.update = false;
  }
  UpdateOrder() {
    this.loading = true;
    const formValue = this.Form.value;
    const updateOrder: UpdateOrder = {
      id: this.order.id,
      firstName: formValue.firstName,
      lastName: formValue.secondName
    };
    if (updateOrder.firstName === undefined && updateOrder.lastName === undefined) {
      return;
    }
    this.orderService.update(updateOrder).pipe(takeUntil(this.unsubscribe)).
    subscribe(x => {this.loading = false; this.update = false; this.Form.reset(); }, error => console.log(error));
  }
  delete() {
    this.orderService.delete(this.id).pipe(takeUntil(this.unsubscribe))
    .subscribe(x => this.router.navigate(['/orders']), error => console.log(error));
  }
  updateForm() {
    this.update = !this.update;
  }
  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.unsubscribe();
  }
}
