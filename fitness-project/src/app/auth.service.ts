import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegisterUserDto, LoginUserDto } from './auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `https://localhost:5001/api/User`; 
  constructor(private http: HttpClient) { }

  register(user: RegisterUserDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(user: LoginUserDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, user);
  }
}
