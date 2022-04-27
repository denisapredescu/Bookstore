import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Author } from 'src/app/interfaces/author';
import { Book } from 'src/app/interfaces/book';
import { NumberBooksWithCategory } from 'src/app/interfaces/number-books-with-category';
import { BookService } from 'src/app/services/book.service';
import { SharedDataService } from 'src/app/services/shared-data.service';
import { ModityBookComponent } from '../../popup/modity-book/modity-book.component';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})


//Componenta Book trimite emailul catre Basket printr-o ruta cu param
//Componenta Book trimite emailul catre Order printr-o ruta cu param

//comunicarea dintre Author si Category cu Book se face prin relatia parinte-copil (input)
//Book (parinte) trimite informatii doar copilului Category (Output)

export class BookComponent implements OnInit, OnDestroy {

  public subscription: Subscription;
  public sharedEmail: string = '';   //se transmite date din AuthComponent => avem nevoie in BookComponent de emailul celui logat
                                     //se transmit prin server
  public displayedColumns = ['name', 'price', 'year', 'noPages', 'noVolume', 'seriesName', 'edit', 'delete', 'addToBasket'];
  public books: Book[];
  public role: string = localStorage.getItem('Role');

  public parentMessage: NumberBooksWithCategory[];   //trimit lista catre componenta Category 
  
  //BookComponent primeste de la componentele copil: CategoryComponent, AuthorComponent datele selectate de user
  public givenFromAuthorComponent: Author = {id: 0, firstName: 'default', lastName: 'default'};
  public givenNameFromCategoryComponent: string = 'default';
                        
  constructor(
    private router: Router,
    private sharedDataService: SharedDataService,
    private bookService: BookService,
    public dialog: MatDialog,
  ) { }


  ngOnInit(): void {

    this.subscription = this.sharedDataService.currentEmailUser.subscribe((sharedEmail) => this.sharedEmail = sharedEmail);

    //Userul nu trebuie sa poata sa faca modificari
    this.columns();
    
    this.bookService.getAllBooks().subscribe(
      (result: Book[]) => {
        console.log(result);
        this.books = result;
      },
      (error) => {
        console.error(error);
      });

    this.bookService.noBooksWithCategory().subscribe(
      (response) => 
      {
        this.parentMessage = response;
        console.log("s-a actualizat lista din parinte", this.parentMessage);
      },
      (error)=>{
        console.error(error);
      });
  }

  public columns(): void{
    if(this.role === 'User')
    this.displayedColumns = ['name', 'price', 'year', 'noPages', 'noVolume', 'seriesName','addToBasket'];   //nu vor mai aparea in tabel anumite coloane daca este logat un user (nu admin)
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public auth(): void{
    this.router.navigate(['/auth']);
  }

  
  public receiveMessageFromAuthor(event): void{
    console.log(event);
    this.givenFromAuthorComponent = event;
  }
  public receiveMessageFromCategory(event): void{
    console.log(event);
    this.givenNameFromCategoryComponent = event;
  }

  public logout(): void{
    this.sharedDataService.changeUserData('default email');
    //pun valorile default
    localStorage.setItem('Role', 'User');
    localStorage.setItem('accessToken', '');
    localStorage.setItem('refreshToken', '');
    
    this.role = localStorage.getItem('Role');  //va disparea butonul de Add Book
    this.columns();
  
  }

  public delete(book: Book): void{
    console.log(book);
    this.bookService.deleteBook(book).subscribe(
      (response)=>{
        this.books = response;
      },
      (error) =>{
          console.error(error);
      }
    );
  }

  public edit(book: Book): void{
    this.openModal(book);

  }
  public add(): void{
    this.openModal();
  }

  public openModal(book?): void {
    const data = {
      book
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    
    const dialogRef = this.dialog.open(ModityBookComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.books = result;
      }
    });
  }
  
  public addToBasket(book: Book): void{

    console.log(this.sharedEmail);
    if(this.sharedEmail == 'default email')
        this.router.navigate(['/auth']);
    else
    {
      this.bookService.addBasketToUser(this.sharedEmail).subscribe(
        (response)=>{
            this.bookService.addToBookBasket(book.id, this.sharedEmail).subscribe(
              (response) => {
                console.log("Adaugat");    //doar vad daca a fost adaugat
              },
              (error)=>{
                console.error(error);
              });
        },
        (error)=>{
          console.error(error);
        });
    }
  }

  public saveChangings(): void{
    console.log(this.givenFromAuthorComponent);
    console.log(this.givenNameFromCategoryComponent);
    
    if(this.givenFromAuthorComponent.id != 0)
    {
      console.log(this.givenFromAuthorComponent);
      
      this.bookService.getBooksWithAuthor(this.givenFromAuthorComponent.id).subscribe(
        (response)=>{
          this.books = response;
          this.givenFromAuthorComponent.id = 0; //ca sa nu intre din nou pe selectia anterioara
          if(this.givenNameFromCategoryComponent != 'default'){

            this.bookService.getBookWithCategory(this.givenNameFromCategoryComponent).subscribe(
              (response)=>{
                this.books = response;
                this.givenNameFromCategoryComponent = 'default';
              },
              (error)=>{
                console.error(error);
              });
          }
        },
        (error)=>{
          console.error(error);
        });
    }
    else
      if(this.givenNameFromCategoryComponent != 'default')
      {
        this.bookService.getBookWithCategory(this.givenNameFromCategoryComponent).subscribe(
          (response)=>{
            this.books = response;
            this.givenNameFromCategoryComponent = 'default';
          },
          (error)=>{
            console.error(error);
          });     
      }
      else{  //selectez toate cartile daca nu am apasat pe o categorie sau un autor
        this.bookService.getAllBooks().subscribe(
          (result: Book[]) => {
            this.books = result;
          },
          (error) => {
            console.error(error);
          });
      }
    }  
  //ruta cu parametri
  public goToUserBasket(): void{
    this.router.navigate(['basket/', this.sharedEmail]);
  }

  public goToOrders (): void{
    this.router.navigate(['orders/', this.sharedEmail]);
  }
  
}


