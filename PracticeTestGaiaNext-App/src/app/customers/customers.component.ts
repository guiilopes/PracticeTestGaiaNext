import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

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
    this.eventFilterCustomers = this.filterList ? this.returnFilterList(this.filterList) : this.customers;
  }

  eventFilterCustomers: any = [];
  customers: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCustormers();
  }

  returnFilterList(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.customers.filter(
      customer => customer.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  getCustormers() {
    this.http.get('https://localhost:5001/api/customer').subscribe(response => {
      this.customers = response;
    }, error => {
    console.log(error);
    });
  }

}
