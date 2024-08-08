
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
  request: CalculoInvestimentoRequest = { valorInicial: 0, prazoMeses: 0 };
  response: CalculoInvestimentoResponse | null = null;
  error: string | null = null;

  constructor(private investimentoService: InvestimentoService) { }

  calcular() {
    this.investimentoService.calcularInvestimento(this.request).subscribe(
      data => {
        this.response = data;
        this.error = null;
      },
      error => {
        this.error = 'Erro ao calcular o investimento. Verifique os dados e tente novamente.';
        this.response = null;
      }
    );
  }
}
