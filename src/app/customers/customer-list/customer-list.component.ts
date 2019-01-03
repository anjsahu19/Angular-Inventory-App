import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../shared/customer.service';
import {Customer} from '../shared/customer.model';

import { from } from 'rxjs';
import { Router} from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  constructor(public customerService : CustomerService, public router: Router) { }

  
  ngOnInit() {
    this.customerService.getCustomerList();
    //console.log(Object.getOwnPropertySymbols(Customer));
  }

  showForEdit(Cid : number){
    // debugger;
    // this.customerService.selectedCustomer=Object.assign({},customer);
  
       // this.customerService.editCustomer(customer);
        debugger;
        this.router.navigate(['/customer',Cid]);
  }

  onDelete(Cid : number){
 
    if(confirm('Are you sure you want to delete this record ?')==true){
          this.customerService.deleteCustomer(Cid);
         
    }
  }


}
