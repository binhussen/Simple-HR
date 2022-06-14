import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import formActions from 'src/app/store/actions/form.actions';
import { AppState } from 'src/app/store/models/app.state';
import { environment } from 'src/environments/environment';
import { company } from '../../company/company.model';
import { department } from '../department.model';
interface FormProps {
  title: string;
  actionTitle: string;
  data: department;
  actionType: 'create' | 'edit';
}
@Component({
  selector: 'app-departmentform',
  templateUrl: './departmentform.component.html',
  styleUrls: ['./departmentform.component.scss']
})
export class DepartmentformComponent implements OnInit {

  companies:company[];

  title!: string;
  actionTitle = 'save';
  actionType!: 'create' | 'edit';
  data!:department;
  sourceUrl= environment.apiURL+"departments";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<DepartmentformComponent>,
    @Inject(MAT_DIALOG_DATA) public inputData: FormProps,
    private formBuilder: FormBuilder,private crudService: CrudHttpService,
    private store$: Store<AppState>) { }

  ngOnInit(): void {
    
    this.getAddress();
    const {title, actionTitle, data, actionType } = this.inputData;
    this.title = title;
    this.actionTitle = actionTitle;
    this.data = data;
    this.actionType = actionType;
    this.form = this.formBuilder.group({
      name: new FormControl(this.data?this.data.name:'', [Validators.required]),
      description: new FormControl(this.data?this.data.description:'', [Validators.required]),
      companyId: new FormControl(this.data?this.data.companyId:'', [Validators.required])
    });
  }

  submit() {
    if(this.actionType=='edit'){
      this.sourceUrl= `${this.sourceUrl}/${this.data.id}`;
      console.log(this.sourceUrl);
    }
    const formState = {
      value: {
        id: this.title,
        data: this.form.value,
        submittedToUrl: this.sourceUrl,
        action: this.actionType,
      },
    };
    this.store$.dispatch(formActions.setSubmittingForm(formState));
  
    this.store$
      .select((state) => state.form)
      .pipe(filter((formState) => formState.id === this.title))
      .subscribe((formState) => {
        if (formState.status !== 'PENDING') {
            this.dialogRef.close();
        }
      });
  }

  getAddress(){
    this.crudService.findAll(environment.apiURL+"companies").subscribe((response:company[]) => {
     this.companies= response;
  })};
}
