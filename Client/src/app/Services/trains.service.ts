import { Injectable, OnDestroy } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Subject } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Train } from '../Models/Trains/Train';
import { NewTrain } from '../Models/Trains/NewTrain';
import { FullTrain } from '../Models/Trains/FullTrain';

@Injectable({
  providedIn: 'root'
})
export class TrainsService  implements OnDestroy {


  public baseUrl: string = environment.ApiUrl;
  public routeTrain = '/api/train';
  public headers = new HttpHeaders();

  unsubscribe = new Subject();
  constructor(private http: HttpClient) { }

  getAllTrains(httpParams?: any) {
     return this.http.get<Train[]>(this.baseUrl + this.routeTrain, { observe: 'response', headers: this.headers, params: httpParams });
  }
  addTrain(train: NewTrain) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<Train>(this.baseUrl + this.routeTrain, train, { headers });
  }
  getTrain(id: number, httpParams?: any) {
    // tslint:disable-next-line:max-line-length
    return this.http.get<FullTrain>(this.baseUrl + this.routeTrain + `/${id}`, { observe: 'response', headers: this.headers, params: httpParams });
  }
  deleteTrain(id: number, httpParams?: any) {
    return this.http.delete(this.baseUrl + this.routeTrain + `/${id}`, { observe: 'response', headers: this.headers, params: httpParams});
  }
  searchTrain(word: string, httpParams?: any) {
    return this.http.get<Train[]>(this.baseUrl + this.routeTrain + `/search/${word}`,
    { observe: 'response', headers: this.headers, params: httpParams });
  }
  ngOnDestroy() {
    this.unsubscribe.next();
    this.unsubscribe.unsubscribe();
  }
}
