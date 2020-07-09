import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class Game {
  id: number;
  name: string;
  releaseDate: string;
  system: string;
  psnTrophyCollection: PsnTrophyCollection;
}

class PsnTrophyCollection {
  id: number;
  name: string;
  detail: string;
  iconUrl: string;
  smallIconUrl: string;
}

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get(): Observable<Game[]> {
    return this.http.get<Game[]>(this.baseUrl + 'api/games');
  }
}
