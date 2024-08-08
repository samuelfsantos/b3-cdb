
import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { InvestimentoService } from '../../services/investimento.service';
import { CalculoInvestimentoRequest } from '../../models/CalculoInvestimentoRequest';
import { CalculoInvestimentoResponse } from '../../models/CalculoInvestimentoResponse';

@Component({
  selector: 'app-investimento-calculadora',
  templateUrl: './investimento-calculadora.component.html',
  styleUrls: ['./investimento-calculadora.component.css']
})
export class InvestimentoCalculadoraComponent {
  request: CalculoInvestimentoRequest = { ValorInicial: 0, PrazoMeses: 0 };
  response: CalculoInvestimentoResponse | null = null;

  constructor(private investimentoService: InvestimentoService, private snackBar: MatSnackBar) { }

  calcular() {
    this.investimentoService.calcularInvestimento(this.request).subscribe(
      data => {
        console.log('Dados recebidos:', data);
        this.response = data;
      },
      error => {
        console.log('Erro Log:', error.error);
        const mensagemErro = error.error.Message || 'Erro desconhecido ao calcular o investimento.';
        this.investimentoService.mostrarErro(mensagemErro);
        this.response = null;
      }
    );
  }
}
