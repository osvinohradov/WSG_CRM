import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AviaService {

  constructor(private http: HttpClient) {

  }

  getAviaInvoiceShort() {
    return this.http.get('http://localhost:9975/api/AviaInvoice/GetAllShortInvoices');
  }

  getAviaInvoice(id: any) {
    console.log('Get avia invoice full');
  }

  updateAviaInvoice(id: any, invoice: any) {
    console.log('Get avia invoice full');
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
