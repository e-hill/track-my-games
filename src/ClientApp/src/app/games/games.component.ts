import { Component, OnInit } from '@angular/core';
import { GamesService, Game } from './games.service';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent implements OnInit {
  games$: Observable<Game[]>;

  constructor(private gamesService: GamesService) { }

  ngOnInit(): void {
    this.games$ = this.gamesService.getGames().pipe(
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
      })
    );
  }

  getNameClass(game: Game) {
    if (game.archived) {
      return 'text-muted';
    }

    if (game.goals && game.goals.length > 0) {
      if (game.goals.every(x => x.completed)) {
        return 'text-primary';
      }
    }

    return 'text-dark';
  }
}
