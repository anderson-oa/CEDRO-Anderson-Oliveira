import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Prato } from './prato';

@Injectable()

export class PratoService {

  constructor(private _http: HttpClient,
    @Inject('BASE_URL') private _baseUrl: string) {
  }  

  getAll() {
    return this._http.get<Prato[]>(`${this._baseUrl}/prato`);
  }

  getById(id) {
    return this._http.get<Prato>(`${this._baseUrl}/prato/${id}`);
  }

  delete(id) {
    return this._http.delete(`${this._baseUrl}/prato/${id}`);
  }

  submit(prato: Prato) {
    if (prato.pratoId) return this._http.put<string>(`${this._baseUrl}/prato`, prato);
    else return this._http.post<string>(`${this._baseUrl}/prato`, prato);
  }

}
