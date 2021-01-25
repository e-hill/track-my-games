import { Component, OnInit } from '@angular/core';
import { GamesService, Game } from '../games.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { select, Store } from '@ngrx/store';
import { selectGame } from 'src/app/state/games.selectors';
import { updateGame } from 'src/app/state/games.actions';
import { Update } from '@ngrx/entity';

@Component({
  selector: 'app-game-editor',
  templateUrl: './game-editor.component.html',
  styleUrls: ['./game-editor.component.scss']
})
export class GameEditorComponent implements OnInit {
  isComplete: boolean;
  isArchived: boolean;
  gameId: string;
  gameForm: FormGroup = this.fb.group({
    name: this.fb.control('', Validators.required),
    releaseDate: this.fb.control('', Validators.required),
    system: this.fb.control('', Validators.required),
    developer: this.fb.control(''),
    publisher: this.fb.control('')
  });

  constructor(private gamesService: GamesService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private store: Store) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');

    this.store.pipe(select(selectGame, { id: this.gameId }), filter(x => !!x))
      .subscribe((game) => {
        this.gameForm.setValue({
          name: game.name,
          releaseDate: game.releaseDate,
          system: game.system,
          developer: this.defaultIfEmpty(game.developers),
          publisher: this.defaultIfEmpty(game.publishers),
        });

        this.isArchived = game.archived;
        this.isComplete = game.complete;
      });
  }

  defaultIfEmpty(array: string[]) {
    return array && array.length > 0 ? array[0] : '';
  }

  uncompleteGame() {
    this.gamesService.uncompleteGame(this.gameId)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }

  completeGame() {
    this.gamesService.completeGame(this.gameId)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }

  unarchiveGame() {
    this.gamesService.unarchiveGame(this.gameId)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }

  archiveGame() {
    this.gamesService.archiveGame(this.gameId)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }

  onSubmit() {
    var update: Update<Game> = {
      id: this.gameId,
      changes: {
        name: this.gameForm.get('name').value,
        releaseDate: this.gameForm.get('releaseDate').value,
        system: this.gameForm.get('system').value,
      }
    };

    const developer = this.gameForm.get('developer').value;
    if (developer !== '') {
      update.changes.developers = [developer];
    }

    const publisher = this.gameForm.get('publisher').value;
    if (publisher !== '') {
      update.changes.publishers = [publisher];
    }

    this.store.dispatch(updateGame({ update }));
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
