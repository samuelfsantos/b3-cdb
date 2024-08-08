import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CalculoInvestimentoRequest } from '../models/CalculoInvestimentoRequest';
import { CalculoInvestimentoResponse } from '../models/CalculoInvestimentoResponse';

@Injectable({
  providedIn: 'root'
})
export class InvestimentoService {
  private apiUrl = 'https://localhost:44310/api/v1/investmentos/cdb';

  constructor(private http: HttpClient) { }

  calcularInvestimento(request: CalculoInvestimentoRequest): Observable<CalculoInvestimentoResponse> {
    console.log(request);
    return this.http.post<CalculoInvestimentoResponse>(this.apiUrl, request);
  }
}
