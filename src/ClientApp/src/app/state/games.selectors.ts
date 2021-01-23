import { createSelector } from '@ngrx/store';
import { State } from './app.state';
import { Game } from '../games/games.service';

export const selectGames = createSelector(
  (state: State) => state.games,
  (games: Game[]) => games
);
