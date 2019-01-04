import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {Router,ActivatedRoute} from '@angular/router';
import {CustomerService} from '../shared/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
  providers : [CustomerService]
})
export class CustomerComponent implements OnInit {

  Id:number;
  constructor(private _customerService : CustomerService,
              private _Activatedroute:ActivatedRoute,
              private _router:Router,) { }

  ngOnInit() {
    this.resetForm();
    debugger;
    this.Id=this._Activatedroute.snapshot.params['id'];
    this._customerService.getCustomerById(this.Id);
  }

  resetForm(form? : NgForm){
    if(form!=null){
        form.reset();
        this._customerService.selectedCustomer={
          Id:null,
          FirstName:'',
          LastName:'',
          City:'',
          Country:'',
          Phone:''
        }
    }
  }

  onSubmit(form:NgForm){
   
      if(form.value.Id==null){
        this._customerService.postCustomer(form.value);
        this.resetForm(form);
        this._router.navigate(['/Customers'])
      }
      else{
      this._customerService.editCustomer(form.value).then(data =>{
        console.log(data.json());
        this._router.navigate(['/Customers']);
      }).catch(function(err){

      });
        //this.resetForm(form);
       
         
      }
  }

}
