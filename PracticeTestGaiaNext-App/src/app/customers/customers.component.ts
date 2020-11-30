import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Customer } from '../_models/customer';
import { CustomerService } from '../_services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  filter = '';
  eventFilterCustomers: Customer[] = [];
  customers: Customer[] = [];
  modalRef: BsModalRef;

  constructor(
      private customerService: CustomerService
    , private modalService: BsModalService
    ) {}

  get filterList(): string {
    return this.filter;
  }

  set filterList(value: string) {
    this.filter = value;
    this.eventFilterCustomers = this.filterList
      ? this.returnFilterList(this.filterList)
      : this.customers;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

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
