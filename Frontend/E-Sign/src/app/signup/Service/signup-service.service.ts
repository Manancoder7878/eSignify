import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { User } from '../Model/User';

@Injectable({
  providedIn: 'root'
})
export class SignupServiceService {
  http = inject(HttpClient)
  registerUser(user:User){
    return this.http.post<User>("https://localhost:7292/api/Register/register",user)
  }
}
