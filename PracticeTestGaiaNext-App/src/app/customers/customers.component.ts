import { templateJitUrl } from '@angular/compiler';
import { Component, OnInit, TemplateRef } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Customer } from '../_models/customer';
import { CustomerService } from '../_services/customer.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
})
export class CustomersComponent implements OnInit {
  filter = '';
  eventFilterCustomers: Customer[] = [];
  customers: Customer[] = [];
  customer: Customer;
  registerForm: FormGroup;
  saveMode = 'post';
  bodyDeleteCustomer = '';

  constructor(
    private customerService: CustomerService,
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
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

  ngOnInit() {
    this.validation();
    this.getCustomers();
  }

  validation() {
    this.registerForm = this.formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ],
      ],
      companySize: ['', Validators.required],
    });
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  newCustomer(template: any) {
    this.saveMode = 'post';
    this.openModal(template);
  }

  editCustomer(customer: Customer, template: any) {
    this.saveMode = 'put';
    this.openModal(template);
    this.customer = customer;
    this.registerForm.patchValue(customer);
  }

  deleteCustomer(customer: Customer, template: any) {
    this.openModal(template);
    this.customer = customer;
    this.bodyDeleteCustomer = `Deseja eliminar o cliente: ${customer.id} - ${customer.name} ?`;
  }

  confirmeDelete(template: any) {
    this.customerService.deleteCustomer(this.customer.id).subscribe(
      () => {
        template.hide();
        this.getCustomers();
        this.toastr.success('Cliente eliminado.');
      },
      (error) => {
        this.toastr.error(`Não foi possível eliminar. Erro: ${error}`);
      }
    );
  }

  saveCustomer(template: any) {
    if (this.registerForm.valid) {
      if (this.saveMode === 'post') {
        this.customer = Object.assign({}, this.registerForm.value);
        this.customerService.postCustomer(this.customer).subscribe(
          (newCustomer: Customer) => {
            template.hide();
            this.getCustomers();
            this.toastr.success('Cliente inserido.');
          },
          (error) => {
            this.toastr.error(`Não foi possível inserir. Erro: ${error}`);
          }
        );
      } else {
        this.customer = Object.assign(
          { id: this.customer.id },
          this.registerForm.value
        );
        this.customerService.putCustomer(this.customer).subscribe(
          () => {
            template.hide();
            this.getCustomers();
            this.toastr.success('Cliente editado.');
          },
          (error) => {
            this.toastr.error(`Não foi possível editar. Erro: ${error}`);
          }
        );
      }
    }
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
      },
      (error) => {
        this.toastr.error(`Não foi possível carregar os clientes. Erro: ${error}`);
      }
    );
  }
}
