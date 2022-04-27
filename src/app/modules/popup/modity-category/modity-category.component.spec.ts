import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModityCategoryComponent } from './modity-category.component';

describe('ModityCategoryComponent', () => {
  let component: ModityCategoryComponent;
  let fixture: ComponentFixture<ModityCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModityCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModityCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
