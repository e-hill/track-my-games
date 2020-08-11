import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GoalsService, Goal } from './goals.service';
import { take, tap, map } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-goals',
  templateUrl: './goals.component.html',
  styleUrls: ['./goals.component.scss']
})
export class GoalsComponent implements OnInit {
  gameId: string;
  goals$: Observable<Goal[]>;

  constructor(private goalsService: GoalsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');
    this.goals$ = this.goalsService.getGoals(this.gameId);
  }

  addGoal() {
    this.goals$.pipe(take(1))
      .pipe(tap(x => x.push(new Goal())))
      .subscribe(x => this.goals$ = of(x));
  }

  removeGoal(index: number) {
    this.goals$.pipe(take(1))
      .pipe(tap(x => x.splice(index, 1)))
      .subscribe(x => this.goals$ = of(x));
  }

  saveGoals() {
    const goals = [];

    this.goalsService.addGoals(goals, this.gameId)
      .pipe(take(1))
      .subscribe((x) => console.log(x));
  }
}
