import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class PsnGame {
  id: number;
  name: string;
  releaseDate: string;
  system: string;
  earnedTrophies: number;
  totalTrophies: number;

  trophyCollection: {
    id: number;
    name: string;
    detail: string;
    iconUrl: string;
    smallIconUrl: string;
  };
}

export class PsnTrophy {
  id: number;
  name: string;
  detail: string;
  type: string;
  iconUrl: string;
  smallIconUrl: string;
  hidden: boolean;
  rare: number;
  earnedRate: number;
  psnId: number;
}

export class PsnUserProgress {
  earned: boolean;
  earnedDate: string;
  onlineId: string;
  trophy: {
    id: number;
  };
}

@Injectable({
  providedIn: 'root'
})
export class PsnService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get(): Observable<PsnGame[]> {
    return this.http.get<PsnGame[]>(this.baseUrl + 'api/psn/games');
  }

  getPsnTrophies(gameId: string): Observable<PsnTrophy[]> {
    return this.http.get<PsnTrophy[]>(this.baseUrl + `api/psn/trophies/findbygame?gameid=${gameId}`);
  }

  getPsnUserProgress(gameId: string): Observable<PsnUserProgress[]> {
    return this.http.get<PsnUserProgress[]>(this.baseUrl + `api/psn/user-progress/findbygame?gameid=${gameId}`);
  }
}
