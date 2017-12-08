import { Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { SearchService } from './../search.service';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchresultsComponent } from './searchresults.component';
import { MatProgressSpinnerModule } from '@angular/material';
import { Http } from '@angular/http';

describe('SearchresultsComponent', () => {
  let component: SearchresultsComponent;
  let fixture: ComponentFixture<SearchresultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[MatProgressSpinnerModule,
                ],
      declarations: [ SearchresultsComponent ],
      providers:[SearchService,Router]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
