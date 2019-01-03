import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
 import { Observable } from 'rxjs';

import {Customer} from './customer.model'

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  customerList : Customer[]

  selectedCustomer : Customer

  constructor(private http : Http) { }

  getCustomerList(){
    debugger;
    this.http.get('http://localhost:8089/api/Customers').toPromise().then(res=>{
    this.customerList=res.json() as Customer[];
    })
  }
  getCustomerById(Id:number){
      this.http.get('http://localhost:8089/api/Customers/'+Id).toPromise().then(res=>{
      this.selectedCustomer=res.json() as Customer;
      })
  }

  editCustomer(customer : Customer){
    debugger;
      this.http.put('http://localhost:8089/api/Customers/Put/?id='+customer.Id,customer).toPromise().then(res=>{
        var result=res.text();
        console.log(result);
      })
  }

  deleteCustomer(Cid : number){
    debugger;
      this.http.delete('http://localhost:8089/api/Customers/Delete/?id='+Cid).toPromise().then(res=> {
        var result=res.text();
        console.log(result);
        this.getCustomerList();
      })
  }


}
