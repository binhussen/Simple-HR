import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { CrudHttpService } from '../../services/crudHttp.service';
import { taxlookup } from '../tax-lookup.model';
import { TaxformComponent } from '../taxform/taxform.component';

@Component({
  selector: 'app-tax-lookups',
  templateUrl: './tax-lookups.component.html',
  styleUrls: ['./tax-lookups.component.scss']
})
export class TaxLookupsComponent implements OnInit {
  sourceUrl= environment.apiURL+"taxlookups";
  displayedColumns: string[] = ['No','Min', 'Max', 'Parsent', 'PensionRate','Deduction','Action'];
  actions : ['Edit','Delete'];
  dataSource! : taxlookup[];
  constructor(public dialog: MatDialog,private crudService: CrudHttpService) { }

  ngOnInit(): void {
    this.loadData();
  }

  openForm(type :'create'|'edit' |'delete', title:string, data?:taxlookup){
    const dialogRef = this.dialog.open(TaxformComponent, {
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
    await this.crudService.findAll(this.sourceUrl).subscribe((response:taxlookup[]) => {
    this.dataSource=response;
    });
  }

  editTax(id:number){
    this.crudService.findOne(`${this.sourceUrl}/${id}`).subscribe((response:taxlookup) => {
     this.openForm('edit','Update TaxLookup',response);
      });
  }

  deleteTax(id:number){
    this.crudService.deleteOne(`${this.sourceUrl}/${id}`).subscribe();
  }

}
