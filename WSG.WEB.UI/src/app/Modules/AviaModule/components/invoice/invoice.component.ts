import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AviaInvoicePopupComponent } from '../invoicePopup/invoicePopup.component';
import { AviaService } from '../../services/avia.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'avia-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class AviaInvoiceComponent implements OnInit {

  public invoices: Array<any> = [];

  constructor(public dialog: MatDialog, private AviaService: AviaService, private dataService: DataService) {
    
  }

  getAviaInvoices() {
    this.AviaService.getAllInvoices().subscribe((evt: any) => {
      console.log("Result: ", evt);
      this.invoices = evt;
    });
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(AviaInvoicePopupComponent, {
      width: '98%',
      height: '98%'
    });
  }

  ngOnInit() {
    // При загрузке окна 'Накладные авиа билетов', запрашиваем все билеты
    // TODO: Нужны первые 50 билетов
    this.getAviaInvoices();    
  }

  public getDocument(): void {
    console.log('get documents');
  }

  public showFullInvoice(id): void {
    // Если параметр id есть, значит выбран существующий билет, нужно передать его id в диалоговое окно и загрузить выбранный билет.
    // Если параметр id отсутствует, значит создается новый билет, которому номер будет присвоен после сохранения.
    if (id != null) {
      this.dataService.transferInvoiceId(id);
    }
    // Открываем диалоговое окно создания\редактирования билета
    this.openDialog();
  }

}
