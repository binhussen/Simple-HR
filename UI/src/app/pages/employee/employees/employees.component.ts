import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import { environment } from 'src/environments/environment';
import { employee } from '../employee.model';
import { EmployeeformComponent } from '../employeeform/employeeform.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  sourceUrl= environment.apiURL+"employeees";
  displayedColumns: string[] = ['No','Name', 'Gander', 'Phone','Email', 'BirthDate','Action'];
  actions : ['Edit','Delete'];
  dataSource! : employee[];
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) { }

  ngOnInit(): void {
    this.loadData();
  }

  openForm(type :'create'|'edit' |'delete', title:string, data?:employee){
    const dialogRef = this.dialog.open(EmployeeformComponent, {
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
    await this.crudService.findAll(this.sourceUrl).subscribe((response:employee[]) => {
    this.dataSource=response;
    });
  }

  editDepartment(id:number){
    this.crudService.findOne(`${this.sourceUrl}/${id}`).subscribe((response:employee) => {
     this.openForm('edit','Update Employee',response);
      });
  }

  deleteDepartment(id:number){
    this.crudService.deleteOne(`${this.sourceUrl}/${id}`).subscribe();
  }

}
