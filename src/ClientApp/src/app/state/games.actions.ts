import { Update } from '@ngrx/entity';
import { createAction, props } from '@ngrx/store';
import { Game } from '../games/games.service';

export const loadGames = createAction('[Games Page] Load Games');
export const gamesLoadedSuccess = createAction('[Games API] Games Loaded Success', props<{ games: Game[] }>());
export const updateGame = createAction('[Games Page] Update Game', props<{ update: Update<Game> }>());
export const gameUpdatedSuccess = createAction('[Games API] Game Updated Success');
