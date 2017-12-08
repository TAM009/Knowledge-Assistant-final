import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewrecievedfilesComponent } from './viewrecievedfiles.component';

describe('ViewrecievedfilesComponent', () => {
  let component: ViewrecievedfilesComponent;
  let fixture: ComponentFixture<ViewrecievedfilesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewrecievedfilesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewrecievedfilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
