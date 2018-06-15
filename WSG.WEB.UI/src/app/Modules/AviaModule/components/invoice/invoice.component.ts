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

  public shortInvoices: Array<any> = [];

  constructor(public dialog: MatDialog, private AviaService: AviaService, private dataService: DataService) {
    
  }

  getAviaInvoicesShort() {
    this.AviaService.getAviaInvoicesShort().subscribe((evt: any) => {
      console.log("Result: ", evt);
      this.shortInvoices = evt;
    });
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(AviaInvoicePopupComponent, {
      width: '98%',
      height: '98%'
    });
  }

  ngOnInit() {
    this.getAviaInvoicesShort();
    
  }

  public getDocument(): void {
    console.log('get documents');
  }

  public getInvoiceModal(id): void {
    this.dataService.transferInvoiceId(id);
    this.openDialog();
    console.log('getInvoiceModalID = ' + id);
  }

}
