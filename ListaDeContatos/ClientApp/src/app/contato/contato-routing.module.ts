import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContatoFormComponent } from './contato-form/contato-form.component';
import { ContatoListaComponent } from './contato-lista/contato-lista.component';

const routes: Routes = [
  { path: '', component: ContatoListaComponent },
  { path: 'novo', component: ContatoFormComponent },
  { path: 'editar/:id', component: ContatoFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContatoRoutingModule { }
