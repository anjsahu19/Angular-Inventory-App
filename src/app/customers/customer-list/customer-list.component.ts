import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../shared/customer.service';
import { Customer } from '../shared/customer.model';

import { from } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customerList: Customer[];

  constructor(public customerService: CustomerService, public router: Router) { }

  public ngOnInit() {
   this.getCustomers();
    //console.log(Object.getOwnPropertySymbols(Customer));
  }

  public getCustomers(){
    this.customerService.getCustomerList().then(data => {
      this.customerList = data.json() as Customer[];
    }).catch(function () {

    });
  }

  public showForEdit(Cid: number) {
    // debugger;
    // this.customerService.selectedCustomer=Object.assign({},customer);

    // this.customerService.editCustomer(customer);
   
    this.router.navigate(['/customer', Cid]);
  }

  public newForm() {

    this.router.navigate(['/customer']);
  }

  public onDelete(Cid: number) {

    if (confirm('Are you sure you want to delete this record ?') == true) {
      this.customerService.deleteCustomer(Cid).then(res=> {
        var result = res.text();
        console.log(result);
        this.getCustomers();
      }).catch(function(){

      });

    }
  }


}
