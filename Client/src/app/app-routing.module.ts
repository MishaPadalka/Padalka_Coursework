import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TrainsContainerComponent } from './Trains/trains-container/trains-container.component';
import { OrdersContainerComponent } from './Orders/orders-container/orders-container.component';
import { FullTrainComponent } from './Trains/full-train/full-train.component';
import { FullOrderComponent } from './Orders/full-order/full-order.component';

const routes: Routes = [
  {path: '', component: TrainsContainerComponent},
  {path: 'trains', component: TrainsContainerComponent},
  {path: 'orders', component: OrdersContainerComponent},
  {path: 'trains/:id', component: FullTrainComponent},
  {path: 'orders/:id', component: FullOrderComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
