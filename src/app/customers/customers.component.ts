import { Component, OnInit } from '@angular/core';
import {CustomerService} from './shared/customer.service'

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers : [CustomerService]
})
export class CustomersComponent implements OnInit {

  constructor(private customerService : CustomerService) { }

  ngOnInit() {
  }

}
