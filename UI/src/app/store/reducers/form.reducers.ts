import {createReducer, on} from "@ngrx/store";
import formActions from "../actions/form.actions";
import {FormState} from "../models/form.state";

export const initialState: FormState = {
  id: null,
  data: null,
  status: null,
  submittedToUrl: null,
  action:null
}
export const formReducer = createReducer(initialState,
    on(formActions.setSubmittingForm, (state, {value}) => ({...state, ...value, status: 'PENDING'})),
    on(formActions.formSubmittingSuccess, (state, {value}) => ({...state, response: value, status: "SUCCESS"})),
    on(formActions.formSubmittingFailure, (state, {value}) => ({...state, response: value, status: "FAILED"})),
    on(formActions.clearData, (state) => ({ ...state, ...initialState}))
  );