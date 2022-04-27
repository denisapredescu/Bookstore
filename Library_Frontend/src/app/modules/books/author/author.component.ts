import { EventEmitter ,Component, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Author } from 'src/app/interfaces/author';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorDetailsComponent } from '../../popup/author-details/author-details.component';
import { ModityAuthorComponent } from '../../popup/modity-author/modity-author.component';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss']
})
export class AuthorComponent implements OnInit {

  public displayedColumns = [ 'First Name', 'Last Name', 'More details', 'edit', 'delete', 'select'];
  public authors: Author[];
  public authorInfo: any;



  @Output() givenAuthor = new EventEmitter<any>();  //dau parintelui


  constructor(
    private authorService: AuthorService,
    public dialog: MatDialog,
  ) { }


  ngOnInit(): void {

    this.authorService.GetAuthors().subscribe(
      (response)=>{
        console.log(response);
        this.authors = response;
      },
      (error)=>{
        console.error(error);
      });
    

  }

  public isAdmin(): boolean{

    if(localStorage.getItem('Role') === 'User'){
        this.displayedColumns = [ 'First Name', 'Last Name', 'More details', 'select'];
        return false;
    }
    else{
        this.displayedColumns = [ 'First Name', 'Last Name', 'More details', 'edit', 'delete', 'select'];
        return true;
    }
  }

  public edit(author: Author): void{
    this.openModal(author);

  }
  public add(): void{
    this.openModal();
  }

  public openModal(author?): void {
    const data = {
      author
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '350px';
    dialogConfig.data = data;
    
    const dialogRef = this.dialog.open(ModityAuthorComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.authors = result;
      }
    });
  }

  public delete(author: Author): void{
    console.log(author);
    
    this.authorService.DeleteAuthor(author).subscribe(
      (response)=>{
        this.authors=response;
      },
      (error)=>{
        console.error(error);
      });
  }

  public info(author: Author): void{
      console.log(author);

      const dialogConfig = new MatDialogConfig();
      dialogConfig.width = '500px';
      dialogConfig.height = '400px';
      dialogConfig.data = author;
      
      const dialogRef = this.dialog.open(AuthorDetailsComponent, dialogConfig);
      dialogRef.afterClosed().subscribe((result) => {
        console.log(result);
      });
    
  }

  public select(author)   //dau parintelui informatia
  {
    this.givenAuthor.emit(author);
  }

}
