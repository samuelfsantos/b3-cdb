
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { InvestimentoCalculadoraComponent } from './components/investimento-calculadora/investimento-calculadora.component';
import { HomeComponent } from './pages/home/home.component';
import { InvestimentoService } from './services/investimento.service';
import { AppRoutingModule } from './app-routing.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MaterialModule } from './material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list'; 
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    InvestimentoCalculadoraComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    MaterialModule,
    FlexLayoutModule,
    MatListModule,
    MatGridListModule,
    MatSnackBarModule
  ],
  providers: [InvestimentoService, provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }
