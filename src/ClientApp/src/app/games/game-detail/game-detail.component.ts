import { Component, OnInit } from '@angular/core';
import { GamesService, PsnTrophy } from '../games.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: ['./game-detail.component.scss']
})
export class GameDetailComponent implements OnInit {

  trophies$: Observable<PsnTrophy[]>;

  constructor(private gamesService: GamesService, private route: ActivatedRoute) { }

  ngOnInit() {
    const gameId = this.route.snapshot.paramMap.get('id');
    this.trophies$ = this.gamesService.getPsnTrophies(gameId);
  }
}
