import { Component, OnInit } from '@angular/core';
import { Game } from './games.service';
import { select, Store } from '@ngrx/store';
import { loadGames } from '../state/games.actions';
import { selectGames } from '../state/games.selectors';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent implements OnInit {
  games$ = this.store.pipe(select(selectGames));

  constructor(private store: Store) { }

  ngOnInit() {
    this.store.dispatch(loadGames());
  }

  getNameClass(game: Game) {
    if (game.archived) {
      return 'text-super-muted';
    }

    if (game.complete) {
      if (!game.goals || game.goals.length === 0) {
        return 'text-primary';
      }

      return 'text-completed';
    }

    if (game.goals && game.goals.length > 0) {
      if (game.goals.every(x => x.completed)) {
        return 'text-primary';
      }
    }

    return 'text-dark';
  }
}
