import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AviaService {
  baseUrl: String = 'http://localhost:9975/api';
  constructor(private http: HttpClient) {
  }

  getAllInvoices() {
    return this.http.get(this.baseUrl + '/Avia/GetAllInvoices');
  }

  getAviaInvoice(id: any) {
    return this.http.get(this.baseUrl + '/Avia/GetInvoice?id=' + id);
  }

  updateAviaInvoice(invoice: any) {
    return this.http.put(this.baseUrl + '/Avia/UpdateInvoice', invoice);
  }

  createAviaInvoice(invoice: any) {
    console.log('Get avia invoice full');
  }

  printAct() {
    console.log('Get avia invoice full');
  }

  printInvoice() {
    console.log('Get avia invoice full');
  }

  printScore() {
    console.log('Get avia invoice full');
  }

  printScoreWithStamp() {
    console.log('Get avia invoice full');
  }
} 
