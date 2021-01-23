import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadGames } from './state/games.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private store: Store) { }

  ngOnInit() {
    this.store.dispatch(loadGames());
  }
}
