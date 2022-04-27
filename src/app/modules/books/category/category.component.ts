import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Category } from 'src/app/interfaces/category';
import { CategoryService } from 'src/app/services/category.service';
import { ModityCategoryComponent } from '../../popup/modity-category/modity-category.component';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  public displayedColumns = [ 'Category', 'edit',  'select'];
  public categories: Category[]; 
  constructor(
    private categoryService: CategoryService,
    public dialog: MatDialog,
  ) { }

  @Input() messageFromBooks;     //primeste date de la parinte
  @Output() givenCategory = new EventEmitter<string>();

  ngOnInit(): void {
    

    //Nu gaseste functia
    this.categoryService.getCategories().subscribe(
      (response)=>{
        this.categories = response;
        console.log(this.categories);
      },
      (error)=>{
        console.log(error);
      });    
  }

  public isAdmin(): boolean{

    if(localStorage.getItem('Role') === 'User'){
        this.displayedColumns = [ 'Category', 'select'];
        return false;
    }
    else{
        this.displayedColumns = [ 'Category','edit',  'select'];
        return true;
    }
  }

  public select(category: Category): void{
    this.givenCategory.emit(category.name);
  }

  public delete(category: Category): void{
      this.categoryService.DeleteCategories().subscribe(
        (response) => {
          this.categories = response;
        },
        (error)=>{
          console.error(error);
        });

  }

  public edit(category: Category): void{
    console.log("in edit");
    this.openModal(category);
  }

  public add(): void{
    this.openModal();
  }

  public openModal(category?): void {
    const data = {
      category
    }

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '300px';
    dialogConfig.height = '250px';
    dialogConfig.data = data;

    console.log("in openModal");
    
    const dialogRef = this.dialog.open(ModityCategoryComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.categories = result;
      }
    });
  }

}
