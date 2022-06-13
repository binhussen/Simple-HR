import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddressformComponent } from '../addressform/addressform.component';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  
  loading = false;

  constructor(public dialog: MatDialog) {

  }
  ngOnInit(): void {
    
  }

  openForm(type :'create'|'edit'){
      const dialogRef = this.dialog.open(AddressformComponent, {
        width: '75%',
        maxWidth: '100vw',
        disableClose: true,
        data: {
          title:"Create Address",
          actionTitle: "Create",
          data: "",
          actionType: type
        },
      });
      dialogRef.afterClosed().subscribe(async (result) => {
      });
    }
}
