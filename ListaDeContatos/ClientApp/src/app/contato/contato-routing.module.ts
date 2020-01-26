import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContatoComponent } from './contato.component';
import { ContatoFormComponent } from './contato-form/contato-form.component';

const routes: Routes = [
  { path: '', component: ContatoComponent },
  { path: 'novo', component: ContatoFormComponent },
  { path: 'editar/:id', component: ContatoFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContatoRoutingModule { }
