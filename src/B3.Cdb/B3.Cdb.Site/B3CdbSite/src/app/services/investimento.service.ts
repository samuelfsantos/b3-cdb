import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CalculoInvestimentoRequest } from '../models/CalculoInvestimentoRequest';
import { CalculoInvestimentoResponse } from '../models/CalculoInvestimentoResponse';

@Injectable({
  providedIn: 'root'
})
export class InvestimentoService {
  private apiUrl = 'https://localhost:44310/api/v1/investmentos/cdb';

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  calcularInvestimento(request: CalculoInvestimentoRequest): Observable<CalculoInvestimentoResponse> {
    return this.http.post<CalculoInvestimentoResponse>(this.apiUrl, request);
  }

  mostrarErro(mensagem: string) {
    const mensagens = mensagem.split(',').map(m => m.trim()).filter(m => m.length > 0);
    const mensagemFormatada = mensagens.join('\n');

    this.snackBar.open(mensagemFormatada, 'Fechar', {
      duration: 15000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: ['error-snackbar']
    });
  }

}
