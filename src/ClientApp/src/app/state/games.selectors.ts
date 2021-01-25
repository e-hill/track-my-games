import { createFeatureSelector, createSelector } from '@ngrx/store';
import { State } from './app.state';
import { Game } from '../games/games.service';
import { gamesSelectors } from './games.reducer';

export const selectGameState = createFeatureSelector<State>('games');

export const selectGames = createSelector(
  (s: State) => s.games,
  gamesSelectors.selectAll,
);

export const selectGame = createSelector(
  selectGames,
  (games: Game[], props: { id: string }) => games.find(x => x.id.toString() === props.id)
)
