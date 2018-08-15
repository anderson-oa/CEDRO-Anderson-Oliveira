import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Restaurante } from './restaurante';

@Injectable()

export class RestauranteService {

  constructor(private _http: HttpClient,
    @Inject('BASE_URL') private _baseUrl: string) {
  }  

  getAll() {
    return this._http.get<Restaurante[]>(`${this._baseUrl}/restaurante`);
  }

  getById(id) {
    return this._http.get<Restaurante>(`${this._baseUrl}/restaurante/${id}`);
  }

  delete(id) {
    return this._http.delete<string>(`${this._baseUrl}/restaurante/${id}`);
  }

  submit(restaurante: Restaurante) {
    if (restaurante.restauranteId) return this._http.put<string>(`${this._baseUrl}/restaurante`, restaurante);
    else return this._http.post<string>(`${this._baseUrl}/restaurante`, restaurante);
  }

}
