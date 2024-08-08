import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestimentoCalculadoraComponent } from './investimento-calculadora.component';

describe('InvestimentoCalculadoraComponent', () => {
  let component: InvestimentoCalculadoraComponent;
  let fixture: ComponentFixture<InvestimentoCalculadoraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvestimentoCalculadoraComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvestimentoCalculadoraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
