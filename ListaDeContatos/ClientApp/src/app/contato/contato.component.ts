import { Component, OnInit } from '@angular/core';
import { ContatoService } from './contato.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable, empty } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FormBuilder, FormGroup } from '@angular/forms';

import { faTrashAlt, faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.css']
})
export class ContatoComponent implements OnInit {
  faTrashAlt = faTrashAlt;
  faEdit = faEdit;
  form: FormGroup;
  contatos$: Observable<any[]>;

  constructor(
    private fb: FormBuilder,
    private contatosService: ContatoService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      nome: [""],
      cpf: [""]
    });

    this.onRefresh(this.form.value.nome, this.form.value.cpf);
  }

  onRefresh(nome, cpf) {
    this.contatos$ = this.contatosService.list(nome, cpf).pipe(
      catchError(error => {
        console.error(error);
        return empty();
      })
    );
    console.log(this.contatos$);
  }

  onSearch() {
    this.onRefresh(this.form.value.nome, this.form.value.cpf);
  }

  onEdit(id) {
    this.router.navigate(['editar', id], { relativeTo: this.route });
  }

  onDelete(contato) {

    if (confirm(`Você tem certeza que deseja deletar o contato de "${contato.nome}"`)) {
      this.contatosService.delete(contato.id).subscribe(
        success => {
          this.onRefresh(this.form.value.nome, this.form.value.cpf);
        }
      );
    }
  }


  calculaIdade(nascimento) {
    console.log(nascimento);
    let data = new Date(nascimento);
    let hoje = new Date();
    return Math.floor(Math.ceil(Math.abs(data.getTime() - hoje.getTime()) / (1000 * 3600 * 24)) / 365.25);
  }

}
