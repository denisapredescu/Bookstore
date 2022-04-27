import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  //metodele din tabelul asociativ sunt puse in service-urile tabelelor Book si Basket
  public urlBookBasket = "https://localhost:44326/api/bookbasket";   //pentru tabelul asociativ
  public urlBasket = "https://localhost:44326/api/basket";

  constructor(
    private http: HttpClient,
  ) { }

  //metoda post de la BasketController se gaseste in BookService

  //determin pretul total al unei comenzi
  public BasketPrice(id: number): Observable<any>{
    console.log("in service", id);
    return this.http.get<any>(`${this.urlBasket}/BasketPrice/${id}`);
  }

  //determin pretul total al unei comenzi
  public getBasketId(email: string): Observable<any>{
    console.log("in service", email);
    return this.http.get<any>(`${this.urlBasket}/getBasketId/${email}`);
  }

  //Clientul face comanda
  public UpdateSentBasket(email: string): Observable<any>{
    return this.http.put<any>(`${this.urlBasket}/UpdateSentBasket/${email}`, null);
  }

  //determin cartile din cos
  public GetBookBasketForUser(email: string): Observable<any>{
    return this.http.get<any>(`${this.urlBookBasket}/GetBookBasketForUser/${email}`);
  }
  
  //sterg toate cartile ce se afla in cos
  public DeleteAllBookBasketByEmail(email: string): Observable<any>{
    return this.http.delete<any>(`${this.urlBookBasket}/DeleteAllBookBasketByEmail/${email}`);
  }

  //creasc numarul de exemplare
  public IncreaseNoCopies(bookBasket): Observable<any>{
    return this.http.put<any>(`${this.urlBookBasket}/IncreaseNoCopies`, bookBasket);
  }

  //scad numarul de exemplare
  public DecreaseNoCopies(bookBasket): Observable<any>{
    return this.http.put<any>(`${this.urlBookBasket}/DecreaseNoCopies`, bookBasket);
  }

  public GetStringBookBasket(email: string): Observable<any>{
    return this.http.get<any>(`${this.urlBasket}/GetStringBookBasket/${email}`);
  }
}

        