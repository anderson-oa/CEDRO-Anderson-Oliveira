import { Component } from '@angular/core';
import { Restaurante } from '../../domain/restaurante/restaurante';
import { RestauranteService } from '../../domain/restaurante/restaurante-sevice';

@Component({
  selector: 'app-restaurante-component',
  templateUrl: './restaurante.component.html',
  styleUrls: ['./restaurante.component.css']
})

export class RestauranteComponent {

  public spinner: boolean = true;

  public modal: boolean = false;

  public toDelete: Restaurante;

  public toFilter = { nome: '' };

  public restaurantes: Restaurante[] = [];

  constructor(private _restauranteService: RestauranteService) {
    this.getAll();  
  }

  getAll() {
    this._restauranteService.getAll().subscribe(restaurantes => {
      this.restaurantes = restaurantes;
      this.spinner = false;
    });
  }

  filter(event: any) {    
    this.toFilter.nome = event.target.value;
  }

  delete(id: number) {
    this.close();
    this.spinner = true;
    this._restauranteService.delete(id)
        .subscribe(() => this.getAll(), () => { this.spinner = false; });
  }

  confirme(restaurante: Restaurante) {
    this.modal = true;
    this.toDelete = restaurante;
  }

  close() {
    this.modal = false;
    this.toDelete = null;
  }

}
