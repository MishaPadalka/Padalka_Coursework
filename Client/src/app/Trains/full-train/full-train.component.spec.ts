import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FullTrainComponent } from './full-train.component';

describe('FullTrainComponent', () => {
  let component: FullTrainComponent;
  let fixture: ComponentFixture<FullTrainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FullTrainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FullTrainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
