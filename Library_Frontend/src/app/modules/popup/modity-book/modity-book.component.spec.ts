import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModityBookComponent } from './modity-book.component';

describe('ModityBookComponent', () => {
  let component: ModityBookComponent;
  let fixture: ComponentFixture<ModityBookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModityBookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModityBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
