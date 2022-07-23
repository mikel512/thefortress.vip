import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VenuesPageComponent } from './venues-page.component';

describe('VenuesPageComponent', () => {
  let component: VenuesPageComponent;
  let fixture: ComponentFixture<VenuesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VenuesPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VenuesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
