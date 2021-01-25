import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError, tap } from 'rxjs/operators';
import { Game, GamesService } from '../games/games.service';
import { loadGames, gamesLoadedSuccess, updateGame, gameUpdatedSuccess } from './games.actions';

@Injectable()
export class AppEffects {

  loadGames$ = createEffect(() => this.actions$.pipe(
    ofType(loadGames),
    mergeMap(() => this.gamesService.getGames()
      .pipe(
        tap(games => {
          games.sort((a, b) => {
            if (a.name > b.name) return 1;
            else if (a.name < b.name) return -1;
            else {
              if (a.releaseDate > b.releaseDate) return 1;
              else if (a.releaseDate < b.releaseDate) return -1;
              else return 0;
            };
          });
        }),
        map(games => (gamesLoadedSuccess({ games }))),
        catchError(() => EMPTY)
      ))
  ));

  updateGame$ = createEffect(() => this.actions$.pipe(
    ofType(updateGame),
    mergeMap(x => this.gamesService.updateGame(x.update)
      .pipe(
        map(() => (gameUpdatedSuccess()))
      )
    )
  ));

  constructor(
    private actions$: Actions,
    private gamesService: GamesService
  ) { }
}
