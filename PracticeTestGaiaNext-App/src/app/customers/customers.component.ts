import { Component, OnInit } from '@angular/core';
import { Customer } from '../_models/customer';
import { CustomerService } from '../_services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  _filterList: string;

  get filterList(): string {
    return this._filterList;
  }

  set filterList(value: string) {
    this._filterList = value;
    this.eventFilterCustomers = this.filterList
      ? this.returnFilterList(this.filterList)
      : this.customers;
  }

  eventFilterCustomers: Customer[] = [];
  customers: Customer[] = [];

  constructor(private customerService: CustomerService) {}

  ngOnInit() {
    this.getCustomers();
  }

  returnFilterList(filterBy: string): Customer[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.customers.filter(
      (customer) => customer.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  getCustomers() {
    this.customerService.getCustomers().subscribe(
      // tslint:disable-next-line: variable-name
      (_customer: Customer[]) => {
        this.customers = _customer;
        this.eventFilterCustomers = this.customers;
        console.log(_customer);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
