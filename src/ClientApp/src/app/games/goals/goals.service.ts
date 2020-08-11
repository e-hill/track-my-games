import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

export class Goal {
  id: string;
  name: string;
  gameId: string;
}

@Injectable({
  providedIn: 'root'
})
export class GoalsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGoals(gameId: string): Observable<Goal[]> {
    return of([]);
    return this.http.get<Goal[]>(this.baseUrl + `api/games/${gameId}/goals`);
  }

  addGoals(goals: Goal[], gameId: string) {
    return this.http.post(this.baseUrl + `api/games/${gameId}/goals`, goals);
  }
}
