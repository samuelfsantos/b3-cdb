import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { CalculoInvestimentoRequest } from '../models/CalculoInvestimentoRequest';
import { CalculoInvestimentoResponse } from '../models/CalculoInvestimentoResponse';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvestimentoService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  calcularInvestimento(request: CalculoInvestimentoRequest): Observable<CalculoInvestimentoResponse> {
    //console.log(this.apiUrl);
    return this.http.post<CalculoInvestimentoResponse>(this.apiUrl, request);
  }

  mostrarErro(mensagens: string[]) {
    const mensagemFormatada = mensagens.join('<br/>') || 'Erro desconhecido ao calcular o investimento.';

    this.toastr.error(mensagemFormatada, 'Não foi possível realizar o cálculo', {
      timeOut: 12000,
      closeButton: true,
      progressBar: true,
      positionClass: 'toast-top-right',
      enableHtml: true 
    });
  }

}
