import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContatoRoutingModule } from './contato-routing.module';
import { ContatoComponent } from './contato.component';
import { ContatoFormComponent } from './contato-form/contato-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgxMaskModule, IConfig } from 'ngx-mask'

export let options: Partial<IConfig> | (() => Partial<IConfig>);

@NgModule({
  declarations: [ContatoComponent, ContatoFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ContatoRoutingModule,
    FontAwesomeModule,
    NgxMaskModule.forRoot(options)
  ]
})
export class ContatoModule { }
