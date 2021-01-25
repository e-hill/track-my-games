import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Goal } from './goals/goals.service';
import { Update } from '@ngrx/entity';

export class Game {
  id: number;
  name: string;
  releaseDate: string;
  system: string;
  archived: boolean;
  complete: boolean;
  developers: string[];
  publishers: string[];
  goals: Goal[];
}

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.baseUrl + 'api/games');
  }

  getGame(gameId: string): Observable<Game> {
    return this.http.get<Game>(this.baseUrl + `api/games/${gameId}`);
  }

  addGame(game: Game) {
    return this.http.post(this.baseUrl + 'api/games', game);
  }

  unarchiveGame(gameId: string) {
    var body = [
      {
        op: 'add',
        path: '/archived',
        value: 'false'
      },
    ];

    return this.http.patch(this.baseUrl + `api/games/${gameId}`, body);
  }

  archiveGame(gameId: string) {
    var body = [
      {
        op: 'add',
        path: '/archived',
        value: 'true'
      },
    ];

    return this.http.patch(this.baseUrl + `api/games/${gameId}`, body);
  }

  uncompleteGame(gameId: string) {
    var body = [
      {
        op: 'add',
        path: '/complete',
        value: 'false'
      },
    ];

    return this.http.patch(this.baseUrl + `api/games/${gameId}`, body);
  }

  completeGame(gameId: string) {
    var body = [
      {
        op: 'add',
        path: '/complete',
        value: 'true'
      },
    ];

    return this.http.patch(this.baseUrl + `api/games/${gameId}`, body);
  }

  updateGame(update: Update<Game>) {
    var body = [
      {
        op: 'add',
        path: '/name',
        value: update.changes.name
      }, {
        op: 'add',
        path: '/releaseDate',
        value: update.changes.releaseDate
      }, {
        op: 'add',
        path: '/system',
        value: update.changes.system
      }, {
        op: 'add',
        path: '/developers',
        value: update.changes.developers
      }, {
        op: 'add',
        path: '/publishers',
        value: update.changes.publishers
      }
    ];

    return this.http.patch(this.baseUrl + `api/games/${update.id}`, body);
  }
}
