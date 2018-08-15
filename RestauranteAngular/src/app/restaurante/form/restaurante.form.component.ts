import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Restaurante } from '../../../domain/restaurante/restaurante';
import { RestauranteService } from '../../../domain/restaurante/restaurante-sevice';
import { MessageService } from '../../../domain/message/message-service';

@Component({
  selector: 'app-restaurante-form-component',
  templateUrl: './restaurante.form.component.html',
  styleUrls: ['./restaurante.form.component.css']
})

export class RestauranteFormComponent {

  public spinner: boolean = false;

  public title: string;

  public formData: FormGroup;

  public model: Restaurante = { restauranteId: 0, nome: '' };

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,    
    private _restauranteService: RestauranteService,
    private _messageService: MessageService) {
  }

  ngOnInit(): void {

    this.formData = this.formBuilder.group({
      restauranteId: [this.model.restauranteId],
      nome: [this.model.nome, [Validators.required, Validators.minLength(2), Validators.maxLength(200)]]
    });

    this.route.params.subscribe(params => {
      var id = params["id"];
      if (id) {
        this._restauranteService.getById(id).subscribe(result => {
          this.title = "Editar";
          this.formData.setValue(result);
        });
      }
      else {
        this.title = "Adicionar";
      }
    });

  }

  onSubmit(fg: FormGroup) {
    if (!fg.valid) return;
    this.spinner = true;
    this._restauranteService.submit(fg.value)
      .subscribe(message => {                
        this.router.navigate(['restaurantes', {message}]);
      }, err => {        
        this._messageService.error(err.error);
        this.spinner = false;
      });
  }

  goToIndex() {
    this.router.navigate(['restaurantes']);
  }

}
