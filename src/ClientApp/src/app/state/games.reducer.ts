import { createReducer, on } from '@ngrx/store';
import * as GamesActions from './games.actions';
import { Game } from '../games/games.service';

const initialState: Game[] = [];

export const gamesReducer = createReducer(
  initialState,
  on(GamesActions.loadGamesSuccess, (_, { games }) => [...games]),
);
