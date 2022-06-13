import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from 'src/environments/environment';
import { CrudHttpService } from '../../services/crudHttp.service';

interface FormProps {
  title: string;
  actionTitle: string;
  data: string;
  actionType: 'create' | 'update';
}

@Component({
  selector: 'app-addressform',
  templateUrl: './addressform.component.html',
  styleUrls: ['./addressform.component.scss']
})
export class AddressformComponent implements OnInit {

  title!: string;
  actionTitle = 'save';
  actionType!: string;
  data!:string;
  sourceUrl= environment.apiURL+"addresses";

  
  form!: FormGroup;

  constructor(public dialogRef: MatDialogRef<AddressformComponent>,
    @Inject(MAT_DIALOG_DATA) public inputData: FormProps,
    private formBuilder: FormBuilder,
    private crudService: CrudHttpService) { }

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
    if (this.actionType === 'create') {
      this.crudService.createOne(this.form.value, this.sourceUrl).subscribe((r) => {
        this.dialogRef.close({
          message: 'Successfully created!',
          success: true,
        });
      });
    }

    if (this.actionType === 'edit') {
      this.crudService.updateOne(this.form.value, this.sourceUrl).subscribe((r) => {
        this.dialogRef.close({
          message: 'Successfully Updated!',
          success: true,
        });
      });
    }
  }

}
