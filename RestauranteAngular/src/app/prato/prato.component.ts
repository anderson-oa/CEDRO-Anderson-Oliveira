import { Component } from '@angular/core';
import { Prato } from '../../domain/prato/prato';
import { PratoService } from '../../domain/prato/prato-service';

@Component({
  selector: 'app-prato-component',
  templateUrl: './prato.component.html',
  styleUrls: ['./prato.component.css']
})

export class PratoComponent {

  public spinner: boolean = true;

  public modal: boolean = false;

  public toDelete: Prato;

  public toFilter = { nome: '' };

  public pratos: Prato[] = [];

  constructor(private _pratoService: PratoService) {
    this.getAll();
  }

  getAll() {
    this._pratoService.getAll().subscribe(pratos => {
      this.pratos = pratos;
      this.spinner = false;
    });
  }

  filter(event: any) {    
    this.toFilter.nome = event.target.value;
  }

  delete(id: number) {
    this.close();
    this.spinner = true;
    this._pratoService.delete(id).subscribe(() => this.getAll());
  }

  confirme(prato: Prato) {
    this.modal = true;
    this.toDelete = prato;
  }

  close() {
    this.modal = false;
    this.toDelete = null;
  }


}
