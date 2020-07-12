import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PsnComponent } from './psn.component';

describe('PsnComponent', () => {
  let component: PsnComponent;
  let fixture: ComponentFixture<PsnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PsnComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PsnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
