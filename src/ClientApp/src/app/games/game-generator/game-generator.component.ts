import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { GamesService, Game } from '../games.service';
import { take } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game-generator',
  templateUrl: './game-generator.component.html',
  styleUrls: ['./game-generator.component.scss']
})
export class GameGeneratorComponent implements OnInit {
  gameForm: FormGroup;

  constructor(private gamesService: GamesService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.gameForm = this.fb.group({
      name: this.fb.control('', Validators.required),
      releaseDate: this.fb.control('', Validators.required),
      system: this.fb.control('', Validators.required),
      archived: this.fb.control(false),
      developer: this.fb.control(''),
      publisher: this.fb.control('')
    });
  }

  onSubmit() {
    var game = new Game();
    game.name = this.gameForm.get('name').value;
    game.releaseDate = this.gameForm.get('releaseDate').value;
    game.system = this.gameForm.get('system').value;
    game.archived = this.gameForm.get('archived').value;

    const developer = this.gameForm.get('developer').value;
    if (developer !== '') {
      game.developers = [developer];
    }

    const publisher = this.gameForm.get('publisher').value;
    if (publisher !== '') {
      game.publishers = [publisher];
    }

    this.gamesService.addGame(game)
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }
}
