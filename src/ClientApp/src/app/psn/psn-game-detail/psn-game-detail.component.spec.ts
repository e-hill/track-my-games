import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PsnGameDetailComponent } from './psn-game-detail.component';

describe('GameDetailComponent', () => {
  let component: PsnGameDetailComponent;
  let fixture: ComponentFixture<PsnGameDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PsnGameDetailComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PsnGameDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
