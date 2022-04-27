import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModityAuthorComponent } from './modity-author.component';

describe('ModityAuthorComponent', () => {
  let component: ModityAuthorComponent;
  let fixture: ComponentFixture<ModityAuthorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModityAuthorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModityAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
