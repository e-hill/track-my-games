import { Component, OnInit } from '@angular/core';
import { GamesService, Game } from './games.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

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
          else return 0;
        });
      })
    );
  }

  complete(game: Game) {
    return game.goals.every(x => x.completed);
  }
}
