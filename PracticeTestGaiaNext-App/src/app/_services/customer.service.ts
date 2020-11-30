import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from '../_models/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseURL = 'https://localhost:5001/api/customer';

  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.baseURL);
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.http.get<Customer>(`${this.baseURL}/${id}`);
  }
}