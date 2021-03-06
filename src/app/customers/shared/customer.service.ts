import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';

import { Customer } from './customer.model'

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  // customerList: Customer[]

  // selectedCustomer: Customer

  constructor(private http: Http) { }

  getCustomerList() {
    
    return this.http.get('http://localhost:8089/api/Customers').toPromise();
    // .then(res => {
    //   this.customerList = res.json() as Customer[];
    // })
  }
  getCustomerById(Id: number) {
    return this.http.get('http://localhost:8089/api/Customers/' + Id).toPromise();
    // .then(res => {
    //   this.selectedCustomer = res.json() as Customer;
    // })
  }

  editCustomer(customer: Customer) {
   debugger;
    var body = JSON.stringify(customer);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:8089/api/Customers/' + customer.Id, body, requestOptions).toPromise();

  }

  deleteCustomer(Cid: number) {
    
    return this.http.delete('http://localhost:8089/api/Customers/Delete/?id=' + Cid).toPromise();
    // .then(res => {
    //   var result = res.text();
    //   console.log(result);
    //   this.getCustomerList();
    // })
  }

  postCustomer(customer: Customer) {

    var body = JSON.stringify(customer);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    return this.http.post('http://localhost:8089/api/Customers/Post', body, requestOptions).toPromise();
    // .then(res => {
    //   var result = res.text();
    //   console.log(result);
    // })
  }


}
