import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Appcomponent4Component } from './appcomponent4.component';

describe('Appcomponent4Component', () => {
  let component: Appcomponent4Component;
  let fixture: ComponentFixture<Appcomponent4Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Appcomponent4Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Appcomponent4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
