import { Component, OnInit } from '@angular/core';
import { PsnService, Game } from './psn.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-psn',
  templateUrl: './psn.component.html',
  styleUrls: ['./psn.component.scss']
})
export class PsnComponent implements OnInit {

  games$: Observable<Game[]>;

  constructor(private psnService: PsnService) { }

  ngOnInit(): void {
    this.games$ = this.psnService.get().pipe(
      tap(games => {
        games.sort((a, b) => {
          if (a.name > b.name) return 1;
          else if (a.name < b.name) return -1;
          else return 0;
        });
      })
    );
  }
}
