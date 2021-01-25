import { createReducer, on } from '@ngrx/store';
import * as GamesActions from './games.actions';
import { Game } from '../games/games.service';
import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';

interface State extends EntityState<Game> { }

const adapter: EntityAdapter<Game> = createEntityAdapter<Game>({
  selectId: (a: Game) => a.id,
  sortComparer: (a: Game, b: Game) => {
    if (a.name > b.name) return 1;
    else if (a.name < b.name) return -1;
    else {
      if (a.releaseDate > b.releaseDate) return 1;
      else if (a.releaseDate < b.releaseDate) return -1;
      else return 0;
    };
  }
});

const initialState: State = adapter.getInitialState([]);

export const gamesReducer = createReducer(
  initialState,
  on(GamesActions.gamesLoadedSuccess, (state, { games }) => adapter.setAll(games, state)),
  on(GamesActions.updateGame, (state, { update }) => adapter.updateOne(update, state)),
);

export const gamesSelectors = adapter.getSelectors();
