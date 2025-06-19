import { HttpClient } from '@angular/common/http';
import {inject, Injectable } from '@angular/core';
import { Login } from '../Model/Login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  http = inject(HttpClient)
  loginUser(login:Login):Observable<{token:string}>{
    return this.http.post<{token:string}>("https://localhost:7292/api/Register/login",login)
  }
  saveToken(token:string){
    localStorage.setItem('token',token);
  }

  getToken():string | null{
    return localStorage.getItem('token');
  }
}
