import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../interfaces/login';
import { LoginResult } from '../interfaces/login-result';
import { Register } from '../interfaces/register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  public url = "https://localhost:44326/api/auth";
  constructor(
    private http: HttpClient
    ) { }


  //observable => promisiuni
  public createLogin(login : Login): Observable<LoginResult>{
    console.log(login);
    return this.http.post<LoginResult>(`${this.url}/Login`, login);
  }
  
  public createRegister(register: Register): Observable<any>{
    console.log(register);
    return this.http.post<any>(`${this.url}/Register`, register);
  }
}
