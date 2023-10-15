import { TestBed } from '@angular/core/testing';

import { ChargeThingsService } from './charge-things.service';

describe('ChargeThingsService', () => {
  let service: ChargeThingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChargeThingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
