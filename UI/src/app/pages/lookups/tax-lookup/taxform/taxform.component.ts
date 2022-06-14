import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import formActions from 'src/app/store/actions/form.actions';
import { AppState } from 'src/app/store/models/app.state';
import { environment } from 'src/environments/environment';
import { taxlookup } from '../tax-lookup.model';
interface FormProps {
  title: string;
  actionTitle: string;
  data: taxlookup;
  actionType: 'create' | 'edit';
} 
@Component({
  selector: 'app-taxform',
  templateUrl: './taxform.component.html',
  styleUrls: ['./taxform.component.scss']
})
export class TaxformComponent implements OnInit {

  title!: string;
  actionTitle = 'save';
  actionType!: 'create' | 'edit' | 'delete';
  data!:taxlookup;
  sourceUrl= environment.apiURL+"taxlookups";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<TaxformComponent>,
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
      min: new FormControl(this.data?this.data.min:'', [Validators.required]),
      max: new FormControl(this.data?this.data.max:'', [Validators.required]),
      parsent: new FormControl(this.data?this.data.parsent:'', [Validators.required]),
      pensionRate: new FormControl(this.data?this.data.pensionRate:'', [Validators.required]),
      deduction: new FormControl(this.data?this.data.deduction:'', [Validators.required])
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

