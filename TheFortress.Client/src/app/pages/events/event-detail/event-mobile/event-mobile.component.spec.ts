import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventMobileComponent } from './event-mobile.component';

describe('EventMobileComponent', () => {
  let component: EventMobileComponent;
  let fixture: ComponentFixture<EventMobileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventMobileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventMobileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
