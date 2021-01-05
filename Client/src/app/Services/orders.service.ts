import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { NewOrder } from '../Models/Orders/NewOrder';
import { Order } from '../Models/Orders/Orders';
import { UpdateOrder } from '../Models/Orders/UpdateOrders';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  public baseUrl: string = environment.ApiUrl;
  public routeOrder = '/api/order';
  public headers = new HttpHeaders();

  unsubscribe = new Subject();

  constructor(private http: HttpClient) { }

  createOrder(newOrder: NewOrder) {
    return this.http.post(this.baseUrl + this.routeOrder, newOrder);
  }
  getAll(httpParams?: any) {
    return this.http.get<Order[]>(this.baseUrl + this.routeOrder, { observe: 'response', headers: this.headers, params: httpParams });
  }
  getById(id: number, httpParams?: any) {
    // tslint:disable-next-line:max-line-length
    return this.http.get<Order>(this.baseUrl + this.routeOrder + `/${id}`, { observe: 'response', headers: this.headers, params: httpParams });
  }
  delete(id: number, httpParams?: any) {
    return this.http.delete(this.baseUrl + this.routeOrder + `/${id}`, { observe: 'response', headers: this.headers, params: httpParams});
  }
  update(update: UpdateOrder, httpParams?: any) {
    return this.http.put(this.baseUrl + this.routeOrder, update, { observe: 'response', headers: this.headers, params: httpParams});
  }
  search(date: Date, httpParams?: any) {
    return this.http.post<Order[]>(this.baseUrl + this.routeOrder + `/search`, date,
    { observe: 'response', headers: this.headers, params: httpParams });
  }
}
