import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {CustomerService} from '../shared/customer.service'
import {CustomerListComponent} from '../customer-list/customer-list.component'
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers : [CustomerService]
})
export class CustomerComponent implements OnInit {

  constructor(private customerService : CustomerService) { }

  ngOnInit() {
    this.resetForm();

  }

  resetForm(form? : NgForm){
    if(form!=null){
        form.reset();
        this.customerService.selectedCustomer={
          Id:null,
          FirstName:'',
          LastName:'',
          City:'',
          Country:'',
          Phone:''
        }
    }
  }

}
