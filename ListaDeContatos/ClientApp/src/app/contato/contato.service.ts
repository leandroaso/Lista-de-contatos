import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { tap, take } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContatoService {
  private readonly URL_API = 'https://localhost:44304/api/contato'

  constructor(
    private http: HttpClient
  ) { }

  list(nome, cpf) {
    if(!nome){
      nome="";
    }
    if(!cpf){
      cpf="";
    }
    
    return this.http.get<any[]>(`${this.URL_API}?nome=${nome}&cpf=${cpf}`)
      .pipe(
        tap(console.log)
      );
  }

  private insert(contato) {
    return this.http.post(this.URL_API, contato).pipe(take(1));
  }

  private update(contato) {
    return this.http.put(`${this.URL_API}`, contato).pipe(take(1));
  }

  save(contato, telefones) {
    contato.dataNascimento = this.dataFormatada(contato.dataNascimento);
    contato.telefones = telefones;
    if (contato.id) {
      return this.update(contato);
    }
    return this.insert(contato);
  }

  getById(id) {
    if (id) {
      return this.http.get<any>(`${this.URL_API}/${id}`);
    }
    return of()
  }

  delete(id) {
    console.log(id);
    console.log(`${this.URL_API}/${id}`);
    return this.http.delete(`${this.URL_API}/${id}`).pipe(take(1));
  }

  dataFormatada(data){
    let dataFormatada = new Date(data),
        dia  = dataFormatada.getDate().toString().padStart(2, '0'),
        mes  = (dataFormatada.getMonth()+1).toString().padStart(2, '0'),
        ano  = dataFormatada.getFullYear();
    return mes+"-"+dia+"-"+ano;
  }
}
