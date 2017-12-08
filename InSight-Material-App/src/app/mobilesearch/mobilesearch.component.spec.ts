import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MobilesearchComponent } from './mobilesearch.component';

describe('MobilesearchComponent', () => {
  let component: MobilesearchComponent;
  let fixture: ComponentFixture<MobilesearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MobilesearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MobilesearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
