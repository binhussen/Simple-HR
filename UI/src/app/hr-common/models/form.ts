export interface Validation {
  type: 'required'
    | 'minLength'
    | 'maxLength'
    | 'max'
    | 'min'
    | 'email'
    | 'phone';
  value: any;
}
export interface FormElement {
  name: string;
  type: 'text'
    | 'select'
    | 'date'
    | 'checkbox'
    | 'radio'
    | 'email'
    | 'number'
    | 'password'| 'formArray';
  placeholder: string;
  defaultValue: any;
  refer?: string;
  size?: number;
  options?: Array<Option>;
  validations?: Array<Validation>;
  formArrayItems?: Array<FormElement>;
}
export interface Option {
  value: string;
  label: string;
  referredValue?: string;
}
export interface Form {
  title: string;
  elements: Array<FormElement>;
}
