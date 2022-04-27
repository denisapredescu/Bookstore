import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../interfaces/book';

@Injectable({
  providedIn: 'root'
})

export class BookService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  //metodele din tabelul asociativ sunt puse in service-urile tabelelor Book si Basket
  //de asemenea, iau si o metoda din BasketController pentru ca in pagina BookComponent selectez cartile pe care vreau sa le pun in cos
  
  public urlBook = "https://localhost:44326/api/book";
  public urlBookBasket = "https://localhost:44326/api/bookbasket";   //pentru tabelul asociativ
  public urlBasket = "https://localhost:44326/api/basket";

  constructor(
    private http: HttpClient
    ) { }


  public addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(`${this.urlBook}/AddBook`, book, this.httpOptions);
  }

  public updateBook(book:Book):Observable<Book> {
    return this.http.put<Book>(`${this.urlBook}/UpdateBook`, book, this.httpOptions);
  }
  
  public deleteBook(book: any): Observable<any> {
    const options = {
      headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
          .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
      body: book,
    };
    return this.http.delete<any>(`${this.urlBook}/DeleteBook`, options);
  }

  public getAllBooks(): Observable<Book[]>{
    return this.http.get<Book[]>(`${this.urlBook}/GetAllBooks`);
  }

  public getBookWithCategory(category: string): Observable<Book[]>{
    return this.http.get<Book[]>(`${this.urlBook}/GetBooksWithCategory/${category}`);
  }

  public getBooksWithAuthor(idAuthor: number): Observable<Book[]>{
    return this.http.get<Book[]>(`${this.urlBook}/GetBooksWithAuthor/${idAuthor}`);
  }
  
  public noBooksWithCategory(): Observable<any> {
    return this.http.get<any>(`${this.urlBook}/NoBooksWithCategory`);
  }

  public addToBookBasket(id: number, email: string): Observable<any> {
    return this.http.post<any>(`${this.urlBookBasket}/AddBookBasket/${id}/${email}`, null);
  }

  public addBasketToUser(email: string): Observable<any> {
    return this.http.post<any>(`${this.urlBasket}/AddBasketToUser/${email}`, null);
  }

}
