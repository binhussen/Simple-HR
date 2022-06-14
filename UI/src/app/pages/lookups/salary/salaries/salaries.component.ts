import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { createAddress } from '../../address/address.model';
import { CrudHttpService } from '../../services/crudHttp.service';
import { createSalary, salary } from '../salary.mode';
import { SalaryformComponent } from '../salaryform/salaryform.component';

@Component({
  selector: 'app-salaries',
  templateUrl: './salaries.component.html',
  styleUrls: ['./salaries.component.scss']
})
export class SalariesComponent implements OnInit {
  data!:salary;
  sourceUrl= environment.apiURL+"salaries";
  displayedColumns: string[] = ['No','Grade', 'Position', 'Growth', 'Pension','Tax', 'Allowance', 'Net','Action'];
  actions : ['Edit','Delete'];
  dataSource! : salary[];
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) { }

  ngOnInit(): void {
    this.loadData();
  }

  openForm(type :'create'|'edit' |'delete', title:string, data?:salary){
    const dialogRef = this.dialog.open(SalaryformComponent, {
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
    await this.crudService.findAll(this.sourceUrl).subscribe((response:salary[]) => {
    this.dataSource=response;
    });
  }

  editSalary(id:number){
    this.crudService.findOne(`${this.sourceUrl}/${id}`).subscribe((response:salary) => {
     this.openForm('edit','Update Salary',response);
      });
  }

  deleteSalary(id:number){
    this.crudService.deleteOne(`${this.sourceUrl}/${id}`).subscribe();
  }

}
