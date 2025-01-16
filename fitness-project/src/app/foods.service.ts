// foods.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FoodsService {

  private baseUrl = 'https://localhost:5005/api/Food';

  constructor(private http: HttpClient) {}

  getFoods(): Observable<any> {
    return this.http.get(this.baseUrl);
  }

  deleteFood(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  addFood(food: any): Observable<any> {
    return this.http.post(this.baseUrl, food);
  }

  updateFood(id: number, food: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, food);
  }
}
