import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { filter } from 'rxjs';
import formActions from 'src/app/store/actions/form.actions';
import { AppState } from 'src/app/store/models/app.state';
import { environment } from 'src/environments/environment';
import { CrudHttpService } from '../../services/crudHttp.service';

interface FormProps {
  title: string;
  actionTitle: string;
  data: string;
  actionType: 'create' | 'edit';
}

@Component({
  selector: 'app-addressform',
  templateUrl: './addressform.component.html',
  styleUrls: ['./addressform.component.scss']
})
export class AddressformComponent implements OnInit {

  title!: string;
  actionTitle = 'save';
  actionType!: 'create' | 'edit';
  data!:string;
  sourceUrl= environment.apiURL+"addresses";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<AddressformComponent>,
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
      country: new FormControl('', [Validators.required]),
      city: new FormControl('', [Validators.required]),
      street: new FormControl('', [Validators.required]),
      website: new FormControl('', Validators.required),
      phone: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      fax: new FormControl('', [Validators.required]),
    });
  }

  submit() {
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
