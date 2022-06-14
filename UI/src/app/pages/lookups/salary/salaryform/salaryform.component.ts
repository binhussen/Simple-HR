import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import formActions from 'src/app/store/actions/form.actions';
import { AppState } from 'src/app/store/models/app.state';
import { environment } from 'src/environments/environment';
import { createAddress } from '../../address/address.model';
import { createSalary, salary } from '../salary.mode';

interface FormProps {
  title: string;
  actionTitle: string;
  data: salary;
  actionType: 'create' | 'edit';
} 
@Component({
  selector: 'app-salaryform',
  templateUrl: './salaryform.component.html',
  styleUrls: ['./salaryform.component.scss']
})
export class SalaryformComponent implements OnInit {


  title!: string;
  actionTitle = 'save';
  actionType!: 'create' | 'edit' | 'delete';
  data!:salary;
  sourceUrl= environment.apiURL+"salaries";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<SalaryformComponent>,
    @Inject(MAT_DIALOG_DATA) public inputData: FormProps,
    private formBuilder: FormBuilder,
    private store$: Store<AppState>) { }

  ngOnInit(): void {
    const {title, actionTitle, data, actionType } = this.inputData;
    this.title = title;
    this.actionTitle = actionTitle;
    this.data = data;
    this.actionType = actionType;
    this.form = this.formBuilder.group({
      grade: new FormControl(this.data.grade??'', [Validators.required]),
      position: new FormControl(this.data.position??'', [Validators.required]),
      growth: new FormControl(this.data.growth??'', [Validators.required]),
      allowance: new FormControl(this.data.allowance??'', [Validators.required])
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

}
