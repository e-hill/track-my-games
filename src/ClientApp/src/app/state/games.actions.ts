import { createAction, props } from '@ngrx/store';
import { Game } from '../games/games.service';

export const loadGames = createAction('[Games Page] Load Games');
export const loadGamesSuccess = createAction('[Games API] Games Loaded Success', props<{ games: Game[] }>());
