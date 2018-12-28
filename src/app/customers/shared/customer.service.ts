import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
 import { Observable } from 'rxjs';

import {Customer} from './customer.model'

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  customerList : Customer[]

  constructor(private http : Http) { }

  getCustomerList(){
    this.http.get('http://localhost:8089/api/Customers').toPromise().then(res=>{
    this.customerList=res.json() as Customer[];
    // console.log(res.json() as Customer[]);
    })
  }

}
