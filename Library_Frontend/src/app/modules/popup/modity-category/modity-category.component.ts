import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Category } from 'src/app/interfaces/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-modity-category',
  templateUrl: './modity-category.component.html',
  styleUrls: ['./modity-category.component.scss']
})
export class ModityCategoryComponent implements OnInit {
  
  public categoryForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
  });

  public title;
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private categoryService: CategoryService,
    public dialogRef: MatDialogRef<ModityCategoryComponent>,
  ) {
    console.log(this.data);
    if (data.category) {
      this.title = 'Edit category name';
      this.categoryForm.patchValue(this.data.category);
    } 
    else {
      this.title = 'Add category';
    }
  }

  ngOnInit() {

  }

  public add(): void{
    this.categoryService.addCategory(this.categoryForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

  public edit(): void{
    this.categoryService.UpdateCategory(this.categoryForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

}
