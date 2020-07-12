import { Component, OnInit } from '@angular/core';
import { PsnService, PsnTrophy } from '../psn.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

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
    this.trophies$ = this.psnService.getPsnTrophies(gameId);
  }
}
