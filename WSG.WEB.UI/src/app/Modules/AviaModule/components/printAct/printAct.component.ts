import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';


@Component({
  selector: 'avia-print-act-popup',
  templateUrl: './printAct.component.html',
  styleUrls: ['./printAct.component.css' ]
})
export class AviaPrintActPopupComponent implements OnInit {

  public currency: Array<Object> = [
    {value: 'currency-1', viewValue: 'грн'},
    {value: 'currency-2', viewValue: '$'},
    {value: 'currency-3', viewValue: 'euro'}
  ];
  
  constructor(
    public dialogRef: MatDialogRef<AviaPrintActPopupComponent>
  ) { }

  ngOnInit() {
  }

  closePopup(): void {
    this.dialogRef.close();
  }
}
