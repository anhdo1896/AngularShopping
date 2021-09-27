import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IOrder } from '../shared/models/order';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrdersForUser(){
    console.log("aaa");
    
    return this.http.get<IOrder[]>(this.baseUrl + 'order');
  }

  getOrderDetailed(id: number){
    return this.http.get<IOrder>(this.baseUrl+'order/' + id);
  }

}
