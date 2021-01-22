import { Component, OnInit } from '@angular/core';
import { GamesService, Game } from '../games.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';

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

  constructor(private gamesService: GamesService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');

    this.gamesService.getGame(this.gameId)
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
    var game = new Game();
    game.name = this.gameForm.get('name').value;
    game.releaseDate = this.gameForm.get('releaseDate').value;
    game.system = this.gameForm.get('system').value;

    const developer = this.gameForm.get('developer').value;
    if (developer !== '') {
      game.developers = [developer];
    }

    const publisher = this.gameForm.get('publisher').value;
    if (publisher !== '') {
      game.publishers = [publisher];
    }

    this.gamesService.updateGame(game, this.gameId)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }
}
