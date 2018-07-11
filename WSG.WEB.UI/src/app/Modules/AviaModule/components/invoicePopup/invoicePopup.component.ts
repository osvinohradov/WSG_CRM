import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { AviaService } from '../../services/avia.service';
import { AviaInvoice } from '../../models/aviaInvoice';

@Component({
  selector: 'app-invoice-popup',
  templateUrl: './invoicePopup.component.html',
  styleUrls: ['./invoicePopup.component.css', './../invoice/invoice.component.css', './../groupInvoice/groupInvoice.component.css']
})
export class AviaInvoicePopupComponent implements OnInit {

  public paymentType: Array<Object> = [
    {value: 'currency-1', viewValue: 'Готівка'},
    {value: 'currency-2', viewValue: 'Кредитна картка'},
    {value: 'currency-3', viewValue: 'Банкiвськiй кредит'}
  ];

  public currencyType: Array<Object> = [
    {value: 'currency-4', viewValue: 'грн'},
    {value: 'currency-5', viewValue: '$'},
    {value: 'currency-6', viewValue: 'euro'}
  ];
 
  public currencyExchange: Array<Object> = [
    {value: 'currency-4', viewValue: 'NBU'},
    {value: 'currency-5', viewValue: 'currency exchange1'},
    {value: 'currency-6', viewValue: 'currency exchange2'}
  ];

  public invoice: AviaInvoice;
  public myField = "111111";
  constructor(private aviaService: AviaService, private dataService: DataService) { }

  ngOnInit() {
    this.invoice = new AviaInvoice();
    // При построении компонента, мы получаем id накладной, и запрашиваем полный билет
    this.dataService.currentMessage.subscribe(msg => {
      console.log('Invoice Id from Invoice PopUp component: ', msg);
      this.aviaService.getAviaInvoice(msg).subscribe((evt: any) => {
        console.log('Getting full invoice');
        let invoice = this.invoice.desirialize(evt);
        console.log('Invoice object: ', invoice)
      });
    });   
  }

  updateInvoice(invoice: any) {
    this.aviaService.updateAviaInvoice(invoice).subscribe(() => {
      console.log('updated')
    });
  }
}
