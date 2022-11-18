import {ComponentFixture, TestBed} from '@angular/core/testing';

import {PostalCodesComponent} from './postal-codes.component';

describe('PostalcodesListComponent', () => {
  let component: PostalCodesComponent;
  let fixture: ComponentFixture<PostalCodesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PostalCodesComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(PostalCodesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
