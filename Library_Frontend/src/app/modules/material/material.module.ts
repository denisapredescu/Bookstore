import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatButtonModule
} from '@angular/material/button';
import {
  MatCardModule
} from '@angular/material/card';
import {
  MatDialogModule, MatDialogRef
} from '@angular/material/dialog';
import {
  MatFormFieldModule
} from '@angular/material/form-field';
import {
  MatIconModule
} from '@angular/material/icon';
import {
  MatInputModule
} from '@angular/material/input';
import {
  MatTableModule
} from '@angular/material/table';
import {
  MatTabsModule
} from '@angular/material/tabs';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatDialogModule,
    MatCardModule,
    MatTabsModule,
  ],
  exports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatDialogModule,
    MatCardModule,
    MatTabsModule,
  ]
})
export class MaterialModule { }
