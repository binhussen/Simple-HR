import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import { environment } from 'src/environments/environment';
import { company } from '../company.model';
import { CompanyformComponent } from '../companyform/companyform.component';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.scss']
})
export class CompaniesComponent implements OnInit {
  sourceUrl= environment.apiURL+"companies";
  displayedColumns: string[] = ['No','Name', 'Type', 'Address','Action'];
  actions : ['Edit','Delete'];
  dataSource! : company[];
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) { }

  ngOnInit(): void {
    this.loadData();
  }

  openForm(type :'create'|'edit' |'delete', title:string, data?:company){
    const dialogRef = this.dialog.open(CompanyformComponent, {
      width: '75%',
      maxWidth: '100vw',
      disableClose: true,
      data: {
        title:title,
        actionTitle:type,
        data: data,
        actionType: type
      },
    });
    dialogRef.afterClosed().subscribe(async (result) => {
    });
  }

  async loadData() {
    await this.crudService.findAll(this.sourceUrl).subscribe((response:company[]) => {
    this.dataSource=response;
    });
  }

  editCompany(id:number){
    this.crudService.findOne(`${this.sourceUrl}/${id}`).subscribe((response:company) => {
     this.openForm('edit','Update Company',response);
      });
  }

  deleteCompany(id:number){
    this.crudService.deleteOne(`${this.sourceUrl}/${id}`).subscribe();
  }

}
