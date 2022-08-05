import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import { CrudHttpService } from 'src/app/services/crudHttp.service';
import formActions from 'src/app/store/actions/form.actions';
import { AppState } from 'src/app/store/models/app.state';
import { environment } from 'src/environments/environment';
import { department } from '../../department/department.model';
import { salary } from '../../lookups/salary/salary.mode';
import { employee } from '../employee.model';
interface FormProps {
  title: string;
  actionTitle: string;
  data: employee;
  actionType: 'create' | 'edit';
}
@Component({
  selector: 'app-employeeform',
  templateUrl: './employeeform.component.html',
  styleUrls: ['./employeeform.component.scss']
})
export class EmployeeformComponent implements OnInit {

  salaries:salary[];
  departments:department[];

  title!: string;
  actionTitle = 'save';
  actionType!: 'create' | 'edit';
  data!:employee;
  sourceUrl= environment.apiURL+"employees";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<EmployeeformComponent>,
    @Inject(MAT_DIALOG_DATA) public inputData: FormProps,
    private formBuilder: FormBuilder,private crudService: CrudHttpService,
    private store$: Store<AppState>) { }

  ngOnInit(): void {
    
    this.getSalary();
    this.getDepartment();
    
    const {title, actionTitle, data, actionType } = this.inputData;
    this.title = title;
    this.actionTitle = actionTitle;
    this.data = data;
    this.actionType = actionType;
    this.form = this.formBuilder.group({
      firstName: new FormControl(this.data?this.data.firstName:'', [Validators.required]),
      lastName: new FormControl(this.data?this.data.lastName:'', [Validators.required]),
      gander: new FormControl(this.data?this.data.gander:'', [Validators.required]),
      birthDate: new FormControl(this.data?this.data.birthDate:'', [Validators.required]),
      status: new FormControl(this.data?this.data.status:'', [Validators.required]),
      phone: new FormControl(this.data?this.data.phone:'', [Validators.required]),
      email: new FormControl(this.data?this.data.email:'', [Validators.required]),
      salaryId: new FormControl(this.data?this.data.salaryId:'', [Validators.required]),
      departmentId: new FormControl(this.data?this.data.departmentId:'', [Validators.required])
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

  getSalary(){
    this.crudService.findAll(environment.apiURL+"salaries").subscribe((response:salary[]) => {
     this.salaries= response;
  })};

  getDepartment(){
    this.crudService.findAll(environment.apiURL+"departments").subscribe((response:department[]) => {
     this.departments= response;
  })};
}
