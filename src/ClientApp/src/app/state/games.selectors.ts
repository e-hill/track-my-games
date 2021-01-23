import { createSelector } from '@ngrx/store';
import { State } from './app.state';
import { Game } from '../games/games.service';

export const selectGames = createSelector(
  (state: State) => state.games,
  (games: Game[]) => games
);

export const selectGame = createSelector(
  selectGames,
  (games: Game[], props: { id: string }) => {
    return games.find(x => x.id === parseInt(props.id))
  }
)
