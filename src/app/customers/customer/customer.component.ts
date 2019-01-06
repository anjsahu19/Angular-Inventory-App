import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from '../shared/customer.service';
import { isUndefined } from 'util';
import { Customer } from '../shared/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers: [CustomerService]
})
export class CustomerComponent implements OnInit {

  Id: number;
  selectedCustomer: Customer;
  customerList: Customer[];

  constructor(private _customerService: CustomerService,
    private _Activatedroute: ActivatedRoute,
    private _router: Router, ) {
    this.selectedCustomer = new Customer();
  }

  ngOnInit() {
    this.resetForm();
    debugger;
    this.Id = this._Activatedroute.snapshot.params['id'];
    if (!isUndefined(this.Id)) {
      this._customerService.getCustomerById(this.Id).then(data => {
        this.selectedCustomer = data.json() as Customer;
      }).catch(function (err) {
      });
    }
    else {
      // TODO: New Form

    }
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
      this.selectedCustomer = {
        Id: null,
        FirstName: '',
        LastName: '',
        City: '',
        Country: '',
        Phone: ''
      }
    }
  }

  onSubmit(form: NgForm) {
    debugger;
    if (this.Id == null) {
      this._customerService.postCustomer(form.value).then(data => {
        this.resetForm(form);
        this._router.navigate(['/Customers'])
      }).catch(function (err) {

      });;

    }
    else {
      this._customerService.editCustomer(this.selectedCustomer).then(data => {
        console.log(data.json());
        this._router.navigate(['/Customers']);
      }).catch(function (err) {

      });
      //this.resetForm(form);


    }
  }

}
