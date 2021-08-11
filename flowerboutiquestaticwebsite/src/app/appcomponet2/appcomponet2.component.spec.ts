import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Appcomponet2Component } from './appcomponet2.component';

describe('Appcomponet2Component', () => {
  let component: Appcomponet2Component;
  let fixture: ComponentFixture<Appcomponet2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Appcomponet2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Appcomponet2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
