import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeriesGeneratorComponent } from './series-generator.component';

describe('SeriesGeneratorComponent', () => {
  let component: SeriesGeneratorComponent;
  let fixture: ComponentFixture<SeriesGeneratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeriesGeneratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeriesGeneratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
