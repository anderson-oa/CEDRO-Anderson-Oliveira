import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Restaurante } from '../../domain/restaurante/restaurante';
import { RestauranteService } from '../../domain/restaurante/restaurante-sevice';
import { MessageService } from '../../domain/message/message-service';

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

  constructor(private router: Router,
    private route: ActivatedRoute,    
    private _restauranteService: RestauranteService,
    private _messageService: MessageService) {
    this.route.params.subscribe(params => {
      this.getAll();
      if(params["message"])_messageService.success(params["message"]);
    });    
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
    this._restauranteService.delete(id).subscribe(result => {
      this.getAll();
      this._messageService.success(result);
    }, err =>{
      this.spinner = false;
      this._messageService.error(err.error);      
    });
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
