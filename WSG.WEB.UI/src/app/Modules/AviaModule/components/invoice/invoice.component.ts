import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'avia-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css', './../../styles/invoicePopup.css', './../../styles/invoice.css']
})
export class AviaInvoiceComponent implements OnInit {

  public aviaDescription:string = 'aviaDescription';

  public invoices: Array<Object> = [
    {
      LastTransactionDate: '1',
      Number : '2',
      Paid: '1',
      ServiceType: '0',
      Provider: '0',
      ProviderTax: '0',
      TotalSum: 'l',
      TotalMPE: 'm',
      PMCode: 'b',
      Curator: '0',
      CurrencyExchange: '0',
      BookingCode: 'l',
      InvoiceId : 2
    },
    {
      LastTransactionDate: '1',
      Number : '2',
      Paid: '1',
      ServiceType: '0',
      Provider: '0',
      ProviderTax: '0',
      TotalSum: 'l',
      TotalMPE: 'm',
      PMCode: 'b',
      Curator: '0',
      CurrencyExchange: '0',
      BookingCode: 'l',
      InvoiceId : 2
    }
  ]



  constructor() { }

  ngOnInit() {
  }

  public getDocument(): void {
    console.log('get documents')
  }

  public getInvoiceModal(id): void {
      console.log('getInvoiceModalID = ' + id)
  }

}
