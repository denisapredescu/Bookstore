import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../interfaces/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public url= "https://localhost:44326/api/category";

  constructor(
    private http: HttpClient
  ) { }


  public addCategory(category): Observable<Category[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
    };
    return this.http.post<Category[]>(`${this.url}/AddCategory`,category, options);
  }
  
  public UpdateCategory(category): Observable<Category[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
    };
    console.log(category);
    return this.http.put<Category[]>(`${this.url}/UpdateCategory`, category, options);
  }

  public DeleteCategories(): Observable<Category[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
    };
    return this.http.delete<Category[]>(`${this.url}/DeleteCategories`, options);
  }

  public getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.url}/GetCategories`);
  }
}
