import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { NewCarriage } from '../Models/Carriages/NewCarriage';
import { Carriage } from '../Models/Carriages/Carriage';

@Injectable({
  providedIn: 'root'
})
export class CarriageService {

  public baseUrl: string = environment.ApiUrl;
  public routeCarriage = '/api/RailwayCarriage';
  public headers = new HttpHeaders();

  unsubscribe = new Subject();
  constructor(private http: HttpClient) { }

  addCarriage(carriage: NewCarriage) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<Carriage>(this.baseUrl + this.routeCarriage, carriage, { headers });
  }
  deleteCarriage(id: number) {
    return this.http.delete(this.baseUrl + this.routeCarriage + `/${id}`);
  }
}
