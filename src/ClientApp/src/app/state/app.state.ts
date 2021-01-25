import { EntityState } from '@ngrx/entity';
import { Game } from '../games/games.service';

export interface State {
  games: EntityState<Game>
}
