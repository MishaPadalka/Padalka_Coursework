import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersContainerComponent } from './orders-container/orders-container.component';
import { FullOrderComponent } from './full-order/full-order.component';
import { AppRoutingModule } from './../app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [OrdersContainerComponent, FullOrderComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class OrdersModule { }
