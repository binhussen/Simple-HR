import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import { environment } from 'src/environments/environment';
import { address } from '../address.model';
import { AddressformComponent } from '../addressform/addressform.component';

export interface Action {
  name: string;
  type:'edit' | 'delete';
}
const data:address[]=
  [
    {
      "id": 4,
      "country": "string",
      "city": "string",
      "street": "string",
      "website": "string",
      "phone": "string",
      "email": "string",
      "fax": "string"
    },
    {
      "id": 5,
      "country": "string",
      "city": "string",
      "street": "string",
      "website": "string",
      "phone": "string",
      "email": "string",
      "fax": "string"
    },
    {
      "id": 6,
      "country": "string",
      "city": "string",
      "street": "string",
      "website": "string",
      "phone": "string",
      "email": "string",
      "fax": "string"
    }
  ];
@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {
  sourceUrl= environment.apiURL+"addresses";
  dataSource = data;

  displayedColumns!:[
    'No',
    'Country',
    'City',
    'Street',
    'Website',
    'Phone',
    'Email',
    'Fax']
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) {

  }
  async ngOnInit() {
    await this.loadData();
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

  async loadData() {
    await this.crudService.findAll(this.sourceUrl).subscribe((response:address[]) => {
    // this.dataSource = new MatTableDataSource(response);
    // console.log(this.dataSource.data);
    });
  }
}
