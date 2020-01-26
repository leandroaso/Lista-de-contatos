import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContatoRoutingModule } from './contato-routing.module';
import { ContatoComponent } from './contato.component';
import { ContatoFormComponent } from './contato-form/contato-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [ContatoComponent, ContatoFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ContatoRoutingModule,
    FontAwesomeModule
  ]
})
export class ContatoModule { }
