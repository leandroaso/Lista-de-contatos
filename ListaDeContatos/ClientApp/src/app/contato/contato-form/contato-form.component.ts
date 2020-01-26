import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { switchMap, map } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';

import { ContatoService } from '../contato.service';

@Component({
  selector: 'contato-form',
  templateUrl: './contato-form.component.html',
  styleUrls: ['./contato-form.component.css']
})
export class ContatoFormComponent implements OnInit {
  faTrashAlt = faTrashAlt;
  form: FormGroup;
  submitted = false;
  telefones: any[] = [];

  constructor(
    private fb: FormBuilder,
    private contatosService: ContatoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.params
      .pipe(
        map((params: any) => params['id']),
        switchMap(id => this.contatosService.getById(id)),
      )
      .subscribe(contato => this.updateForm(contato));

    this.form = this.fb.group({
      id: [0],
      nome: [null, [Validators.required, Validators.minLength(3)]],
      email: [null, Validators.required],
      cpf: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      ddd: [null],
      telefone: [null]
    });
  }

  fildIsValid(fild: string) {
    if (this.dirtyOrTouched(fild) || this.submitted) {
      return this.form.get(fild).errors;
    }

    return null;
  }

  hasError(fild: string) {
    return this.form.get(fild).errors;
  }

  dirtyOrTouched(fild: string) {
    return this.form.get(fild).dirty || this.form.get(fild).touched
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.valid) {
      this.contatosService.save(this.form.value, this.telefones).subscribe(
        success => {
          this.router.navigate(['/']);
        },
        error => {
          console.log("error!!");
          console.log(error);
        }
      );
    }
  }

  onAddTelefone(){
    let telefone = {
      ddd: this.form.value.ddd,
      numero: this.form.value.telefone
    }    
    this.telefones.push(telefone);

    this.form.patchValue({
      ddd: "",
      telefone: "",
    });
  }

  updateForm(contato) {
    this.telefones = contato.telefones;
    console.log(this.telefones);
    
    this.form.patchValue({
      id: contato.id,
      nome: contato.nome,
      email: contato.email,
      cpf: contato.cpf,
      dataNascimento: this.dataFormatada(contato.dataNascimento)
    });
  }

  onCancel() {
    this.router.navigate(['/contato']);
  }

  onDeleteTelefone(index){
    console.log(index)
    this.telefones.splice(index, 1);
  }

  dataFormatada(data){
    let dataFormatada = new Date(data),
        dia  = dataFormatada.getDate().toString().padStart(2, '0'),
        mes  = (dataFormatada.getMonth()+1).toString().padStart(2, '0'),
        ano  = dataFormatada.getFullYear();
    return ano+"-"+mes+"-"+dia;
  }
}
