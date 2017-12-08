
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SettingsComponent } from './settings.component';
<<<<<<< HEAD
import { MatIconModule, MatDatepickerModule } from '@angular/material';
=======
import { MatIconModule } from '@angular/material';
>>>>>>> 1ff27d909bdb84a8572b5b592d5aa3523c59bb67

fdescribe('SettingsComponent', () => {
  let component: SettingsComponent;
  let fixture: ComponentFixture<SettingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
<<<<<<< HEAD
      imports:[MatIconModule,
               MatDatepickerModule,
              ],
      
=======
      imports:[MatIconModule],
      providers:[],
>>>>>>> 1ff27d909bdb84a8572b5b592d5aa3523c59bb67
      declarations: [ SettingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
