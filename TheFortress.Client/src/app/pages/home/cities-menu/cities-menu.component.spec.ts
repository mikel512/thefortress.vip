import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CitiesMenuComponent } from './cities-menu.component';

describe('CitiesMenuComponent', () => {
  let component: CitiesMenuComponent;
  let fixture: ComponentFixture<CitiesMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CitiesMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CitiesMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
