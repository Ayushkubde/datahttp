import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Appcomponent3Component } from './appcomponent3.component';

describe('Appcomponent3Component', () => {
  let component: Appcomponent3Component;
  let fixture: ComponentFixture<Appcomponent3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Appcomponent3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Appcomponent3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
