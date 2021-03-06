import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CustomerListComponent} from './customers/customer-list/customer-list.component';
import {CustomerComponent} from './customers/customer/customer.component';

const routes: Routes = [
  {path : 'Customers', component:CustomerListComponent},
  {path : 'customer/:id', component : CustomerComponent},
  {path : 'customer', component : CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
