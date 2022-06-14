import {ActionReducerMap, MetaReducer} from "@ngrx/store";
import {AppState} from "../models/app.state";
import {environment} from "../../../environments/environment";
import { formReducer } from "./form.reducers";

export const reducers: ActionReducerMap<AppState> = {
  form: formReducer
}

export const metaReducers: MetaReducer<any>[] = !environment.production ? [] : [];