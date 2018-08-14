import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CurrencyMaskModule } from "ng2-currency-mask";

import { AppComponent } from './app.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { MessageComponent } from './message/message.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';

import { RestauranteComponent } from './restaurante/restaurante.component';
import { RestauranteFormComponent } from './restaurante/form/restaurante.form.component';
import { RestauranteFilterPipe } from './restaurante/restaurante-filter.pipe';
import { RestauranteService } from '../domain/restaurante/restaurante-sevice';

import { PratoComponent } from './prato/prato.component';
import { PratoFormComponent } from './prato/form/prato.form.component';
import { PratoFilterPipe } from './prato/prato-filter.pipe';
import { PratoService } from '../domain/prato/prato-service';

@NgModule({
  declarations: [
    AppComponent,    
    SpinnerComponent,
    MessageComponent,
    MenuComponent,
    HomeComponent,
    RestauranteComponent,    
    RestauranteFormComponent,
    RestauranteFilterPipe,
    PratoComponent,
    PratoFormComponent,
    PratoFilterPipe
  ],  
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CurrencyMaskModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full',
        data: {
          title: "Home",
          isMenuOpen: true
        },
      },
      {
        path: 'restaurantes',
        data: {
          title: "Restaurantes",
          isMenuOpen: false
        },
        children: [
          {
            path: '',
            component: RestauranteComponent,           
          },
          {
            path: 'add',
            component: RestauranteFormComponent,          
          },
          {
            path: 'edit/:id',
            component: RestauranteFormComponent,            
          },
        ]       
      },
      {
        path: 'pratos',       
        data: {
          title: "Pratos",
          isMenuOpen: false
        },
        children:[
          {
            path: '',
            component: PratoComponent,           
          },
          {
            path: 'add',
            component: PratoFormComponent,          
          },
          {
            path: 'edit/:id',
            component: PratoFormComponent,            
          },
        ]
      },
    ])
  ],
  providers: [
    RestauranteService, 
    PratoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
