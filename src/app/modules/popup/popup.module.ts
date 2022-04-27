import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ModityBookComponent } from './modity-book/modity-book.component';
import { ModityCategoryComponent } from './modity-category/modity-category.component';
import { ModityAuthorComponent } from './modity-author/modity-author.component';
import { AuthorDetailsComponent } from './author-details/author-details.component';
import { MarksPipe } from 'src/app/marks.pipe';


@NgModule({
  declarations: [
    ModityBookComponent,
    ModityCategoryComponent,
    ModityAuthorComponent,
    AuthorDetailsComponent,
    MarksPipe,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    ModityBookComponent,
    ModityAuthorComponent,
    ModityCategoryComponent,
    AuthorDetailsComponent,
  ],
  exports:[
    MarksPipe,
  ],
})

export class PopupModule { }
