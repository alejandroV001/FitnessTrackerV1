// workouts.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsService {

  private baseUrl = 'https://localhost:5003/api/Exercise';

  constructor(private http: HttpClient) {}

  getMuscleGroups(): Observable<any> {
    return this.http.get(`${this.baseUrl}/muscle-groups`);
  }

  addMuscleGroup(muscleGroup: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/muscle-group`, muscleGroup);
  }

  updateMuscleGroup(id: number, muscleGroup: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/muscle-group/${id}`, muscleGroup);
  }

  deleteMuscleGroup(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/muscle-group/${id}`);
  }
}
