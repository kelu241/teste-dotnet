import { Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import Pessoa from '../../iterface/pessoa';
import {Observable, Observer} from 'rxjs';
import PessoaService from '../../service/pessoa-service';

@Component({
  selector: 'app-tabela',
  imports: [MatTableModule, MatPaginatorModule],
  templateUrl: './tabela.component.html',
  styleUrl: './tabela.component.scss'
})
export class TabelaComponent implements OnInit {

  

  constructor(private pessoaService: PessoaService){}

  observer: Observer<Pessoa[]> = {next:(p: Pessoa[] | undefined) => this.dataSource = p ?? [], error: () => console.log( "deu ruim"), complete: () => console.log("completo")}

  displayedColumns: string[] = ['ID', 'name'];

  dataSource: Pessoa[] = [];

  pessoas!: Observable<Pessoa[]>;

  ngOnInit(){

    this.pessoas = this.pessoaService.getPessoa();
    this.pessoas.subscribe(this.observer)

  }

}








