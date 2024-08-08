
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
    FlexLayoutModule
  ],
  providers: [InvestimentoService, provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }
