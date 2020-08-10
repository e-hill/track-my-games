import { Component, OnInit } from '@angular/core';
import { PsnService, PsnTrophy } from '../psn.service';
import { Observable, forkJoin } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-psn-game-detail',
  templateUrl: './psn-game-detail.component.html',
  styleUrls: ['./psn-game-detail.component.scss']
})
export class PsnGameDetailComponent implements OnInit {

  trophies$: Observable<PsnTrophy[]>;

  constructor(private psnService: PsnService, private route: ActivatedRoute) { }

  ngOnInit() {
    const gameId = this.route.snapshot.paramMap.get('id');

    const psnTrophies = this.psnService.getPsnTrophies(gameId);
    const psnUserProgress = this.psnService.getPsnUserProgress(gameId);

    this.trophies$ = forkJoin([psnTrophies, psnUserProgress]).pipe(
      map(x => {
        return x[0].map(trophy => {
          const userProgress = x[1].filter(y => y.trophy.id == trophy.id);

          if (userProgress.length > 0 && userProgress[0].earned) {
            return {
              ...trophy,
              earned: userProgress[0].earned,
              earnedDate: new Date(userProgress[0].earnedDate),
            };
          }

          return trophy;
        });
      }));
  }
}
