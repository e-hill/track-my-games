import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { GamesService, Game } from '../games.service';
import { catchError, takeUntil, take } from 'rxjs/operators';

@Component({
  selector: 'app-game-generator',
  templateUrl: './game-generator.component.html',
  styleUrls: ['./game-generator.component.scss']
})
export class GameGeneratorComponent implements OnInit {
  gameForm: FormGroup;

  constructor(private gamesService: GamesService, private fb: FormBuilder) { }

  ngOnInit() {
    this.gameForm = this.fb.group({
      name: this.fb.control('', Validators.required),
      releaseDate: this.fb.control('', Validators.required),
      system: this.fb.control('', Validators.required),
      developer: this.fb.control(''),
      publisher: this.fb.control('')
    });
  }

  onSubmit() {
    var game = new Game();
    game.name = this.gameForm.get('name').value;
    game.releaseDate = this.gameForm.get('releaseDate').value;
    game.system = this.gameForm.get('system').value;

    this.gamesService.addGame(game)
      .pipe(take(1))
      .subscribe((x) => console.log(x));
  }
}
