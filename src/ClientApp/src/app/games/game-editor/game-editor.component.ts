import { Component, OnInit } from '@angular/core';
import { GamesService, Game } from '../games.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-game-editor',
  templateUrl: './game-editor.component.html',
  styleUrls: ['./game-editor.component.scss']
})
export class GameEditorComponent implements OnInit {
  gameId: string;
  gameForm: FormGroup = this.fb.group({
    name: this.fb.control('', Validators.required),
    releaseDate: this.fb.control('', Validators.required),
    system: this.fb.control('', Validators.required),
    developer: this.fb.control(''),
    publisher: this.fb.control('')
  });

  constructor(private gamesService: GamesService, private fb: FormBuilder, private route: ActivatedRoute) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');

    this.gamesService.getGame(this.gameId)
      .pipe(take(1))
      .subscribe((game) => {
        this.gameForm.setValue({
          name: game.name,
          releaseDate: game.releaseDate,
          system: game.system,
          developer: this.defaultIfEmpty(game.developers),
          publisher: this.defaultIfEmpty(game.publishers),
        });
      });
  }

  defaultIfEmpty(array: string[]) {
    return array && array.length > 0 ? array[0] : '';
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
      .pipe(take(1))
      .subscribe((x) => console.log(x));
  }
}
