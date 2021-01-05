import { TestBed } from '@angular/core/testing';

import { CarriageService } from './carriage.service';

describe('CarriageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CarriageService = TestBed.get(CarriageService);
    expect(service).toBeTruthy();
  });
});
