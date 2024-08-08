
import { Component } from '@angular/core';
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

  constructor(private investimentoService: InvestimentoService) { }

  calcular() {
    this.investimentoService.calcularInvestimento(this.request).subscribe(
      data => {
        //console.log('Dados recebidos:', data);
        this.response = data;
      },
      error => {
        //console.log('Erro Log:', error.error);
        this.investimentoService.mostrarErro(error.error);
        this.response = null;
      }
    );
  }
}
