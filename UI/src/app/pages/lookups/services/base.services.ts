import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';

export abstract class BaseService<T> {
  _path!: string;
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });
  constructor(protected httpClient: HttpClient, private path: string) {
    this._path = path;
  }
  findAll(
    customPath?: string,
    params?: { [key: string]: string }
  ): Observable<Array<T>> {
    return this.httpClient
      .get<Array<T>>(customPath ?? this._path, {
        params: new HttpParams({ fromObject: params }),
      })
      .pipe(retry(3));
  }

  findOne(id: string): Observable<T> {
    return this.httpClient.get<T>(`${this._path}/${id}`).pipe(retry(3));
  }

  createOne(item: Omit<T, 'id'>, customPath?: string): Observable<T> {
    return this.httpClient
      .post<T>(customPath ?? this._path, item, {
        headers: this.headers,
      })
      .pipe(retry(3));
  }

  updateOne(
    item: Partial<Omit<T, 'id'>>,
    customPath?: string,
    id?: string
  ): Observable<T> {
    return this.httpClient
      .patch<T>(customPath ?? `${this._path}/${id}`, item)
      .pipe(retry(3));
  }

  deleteOne(id: string, customPath?: string): Observable<boolean> {
    return this.httpClient
      .delete<boolean>(`${customPath ?? this._path}/${id}`)
      .pipe(retry(3));
  }
}
