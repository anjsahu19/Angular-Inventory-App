import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CustomerListComponent} from './customers/customer-list/customer-list.component';
import {CustomerComponent} from './customers/customer/customer.component';
const routes: Routes = [
  {path : 'Customers', component:CustomerListComponent},
  {path : 'Settings', component:CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash: true,enableTracing: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
