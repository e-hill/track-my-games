import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Goal } from './goals/goals.service';

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

  updateGame(game: Game, gameId: string) {
    var body = [
      {
        op: 'add',
        path: '/name',
        value: game.name
      }, {
        op: 'add',
        path: '/releaseDate',
        value: game.releaseDate
      }, {
        op: 'add',
        path: '/system',
        value: game.system
      }, {
        op: 'add',
        path: '/developers',
        value: game.developers
      }, {
        op: 'add',
        path: '/publishers',
        value: game.publishers
      }
    ];

    return this.http.patch(this.baseUrl + `api/games/${gameId}`, body);
  }
}
