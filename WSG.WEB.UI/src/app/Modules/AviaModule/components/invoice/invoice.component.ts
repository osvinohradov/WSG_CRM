import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AviaInvoicePopupComponent } from '../invoicePopup/invoicePopup.component';
import { AviaService } from '../../services/avia.service';

@Component({
  selector: 'avia-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class AviaInvoiceComponent implements OnInit {

  public aviaDescription:string = 'aviaDescription';

  public shortInvoices: Array<any> = [];  

  constructor(public dialog: MatDialog, private AviaService: AviaService) { }

  getAviaInvoiceShort() {
    this.AviaService.getAviaInvoiceShort().subscribe((evt: any) => {
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
  }

  public getDocument(): void {
    console.log('get documents');
  }

  public getInvoiceModal(id): void {
    console.log('getInvoiceModalID = ' + id);
  }

}
