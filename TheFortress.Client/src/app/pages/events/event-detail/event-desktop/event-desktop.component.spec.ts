import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventDesktopComponent } from './event-desktop.component';

describe('EventDesktopComponent', () => {
  let component: EventDesktopComponent;
  let fixture: ComponentFixture<EventDesktopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventDesktopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventDesktopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
