import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCustormers();
  }

  getCustormers() {
    this.http.get('https://localhost:5001/api/customer').subscribe(response => {
      this.customers = response;
    }, error => {
    console.log(error);
    });
  }

}
