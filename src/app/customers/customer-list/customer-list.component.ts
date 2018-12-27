import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../shared/customer.service';
import {Customer} from '../shared/customer.model';
import { from } from 'rxjs';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  constructor(private customerService : CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomerList();
    //console.log(Object.getOwnPropertySymbols(Customer));
  }

}
