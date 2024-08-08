import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CalculoInvestimentoRequest } from '../models/CalculoInvestimentoRequest';
import { CalculoInvestimentoResponse } from '../models/CalculoInvestimentoResponse';

@Injectable({
  providedIn: 'root'
})
export class InvestimentoService {
  private apiUrl = 'http://localhost:5000/api/v1/investmentos/cdb'; // Update with your API endpoint

  constructor(private http: HttpClient) { }

  calcularInvestimento(request: CalculoInvestimentoRequest): Observable<CalculoInvestimentoResponse> {
    return this.http.post<CalculoInvestimentoResponse>(this.apiUrl, request);
  }
}
