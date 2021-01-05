import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainsContainerComponent } from './trains-container.component';

describe('TrainsContainerComponent', () => {
  let component: TrainsContainerComponent;
  let fixture: ComponentFixture<TrainsContainerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainsContainerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
