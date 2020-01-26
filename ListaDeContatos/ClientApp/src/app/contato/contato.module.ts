import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxMaskModule, IConfig } from 'ngx-mask';

import { ContatoRoutingModule } from './contato-routing.module';
import { ContatoFormComponent } from './contato-form/contato-form.component';
import { ContatoListaComponent } from './contato-lista/contato-lista.component'

export let options: Partial<IConfig> | (() => Partial<IConfig>);

@NgModule({
  declarations: [ContatoFormComponent, ContatoListaComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ContatoRoutingModule,
    FontAwesomeModule,
    NgxMaskModule.forRoot(options)
  ]
})
export class ContatoModule { }
