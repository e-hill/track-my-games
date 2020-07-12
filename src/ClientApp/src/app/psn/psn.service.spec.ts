import { TestBed } from '@angular/core/testing';

import { PsnService } from './psn.service';

describe('GamesService', () => {
  let service: PsnService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PsnService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
