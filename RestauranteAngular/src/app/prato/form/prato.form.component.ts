import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Prato } from '../../../domain/prato/prato';
import { PratoService } from '../../../domain/prato/prato-service';
import { Restaurante } from '../../../domain/restaurante/restaurante';
import { RestauranteService } from '../../../domain/restaurante/restaurante-sevice';

@Component({
  selector: 'app-prato-form-component',
  templateUrl: './prato.form.component.html',
  styleUrls: ['./prato.form.component.css']
})

export class PratoFormComponent {  

  public spinner: boolean = false;

  public title: string;

  public formData: FormGroup;

  public restaurantes: Restaurante[] = [];
  
  public model: Prato = { 
    pratoId:0, 
    nome: '', 
    preco:0,  
    restauranteId: 0, 
    restaurante: null,
  };

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private _pratoService: PratoService,
    private _restauranteService: RestauranteService) {
  }

  ngOnInit(): void {

    this._restauranteService.getAll().subscribe(restaurantes => this.restaurantes = restaurantes);

    this.formData = this.formBuilder.group({
      pratoId: [this.model.pratoId],      
      nome: [this.model.nome, [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      preco: [this.model.preco, [Validators.required]],
      restauranteId: [this.model.restauranteId, [Validators.min(1)]]    
    });

    let id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this._pratoService.getById(id).subscribe(result => {
        this.title = "Editar";        
        this.formData.setValue(result);
      });
    }
    else {
      this.title = "Adicionar";
    }

  }

  onSubmit(fg: FormGroup) {        
    if (!fg.valid) return;
    this.spinner = true;
    this._pratoService.submit(fg.value)
        .subscribe(() => this.goToIndex(), () => {
          this.spinner = false;        
        });
  }

  goToIndex() {
    this.router.navigate(['pratos']);
  }

}
