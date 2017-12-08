import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchbarComponent } from './searchbar.component';
import { RouterModule } from '@angular/router';

describe('SearchbarComponent', () => {
  let component: SearchbarComponent;
  let fixture: ComponentFixture<SearchbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[RouterModule],
      declarations: [ SearchbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
