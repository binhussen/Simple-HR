import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import { environment } from 'src/environments/environment';
import { company } from '../../company/company.model';
import { DepartmentformComponent } from '../departmentform/departmentform.component';
interface FormProps {
  title: string;
  actionTitle: string;
  data: company;
  actionType: 'create' | 'edit';
}
@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.scss']
})
export class DepartmentsComponent implements OnInit {
  sourceUrl= environment.apiURL+"departments";
  displayedColumns: string[] = ['No','Name', 'Description', 'Company','Action'];
  actions : ['Edit','Delete'];
  dataSource! : company[];
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) { }

  ngOnInit(): void {
    this.loadData();
  }

  openForm(type :'create'|'edit' |'delete', title:string, data?:company){
    const dialogRef = this.dialog.open(DepartmentformComponent, {
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

  editDepartment(id:number){
    this.crudService.findOne(`${this.sourceUrl}/${id}`).subscribe((response:company) => {
     this.openForm('edit','Update Department',response);
      });
  }

  deleteDepartment(id:number){
    this.crudService.deleteOne(`${this.sourceUrl}/${id}`).subscribe();
  }

}
