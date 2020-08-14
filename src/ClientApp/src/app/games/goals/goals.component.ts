import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormArray } from '@angular/forms';
import { GoalsService, Goal, NewGoal } from './goals.service';
import { take } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-goals',
  templateUrl: './goals.component.html',
  styleUrls: ['./goals.component.scss']
})
export class GoalsComponent implements OnInit {
  gameId: string;

  goalsForm: FormGroup = this.fb.group({
    goals: this.fb.array([], Validators.required)
  });

  get goals() {
    return this.goalsForm.get('goals') as FormArray;
  }

  constructor(private goalsService: GoalsService, private router: Router, private route: ActivatedRoute, private fb: FormBuilder) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');

    this.goalsService.getGoals(this.gameId)
      .pipe(take(1))
      .subscribe(goals => goals.map(goal => this.addGoal(goal)));
  }

  addGoal(goal: Goal = new Goal()) {
    const group = this.fb.group({
      'name': this.fb.control(goal.name, Validators.required),
      'earned': this.fb.control(goal.earned),
      'total': this.fb.control(goal.total, Validators.min(1))
    });

    this.goals.push(group);
  }

  removeGoal(index: number) {
    this.goals.removeAt(index);
  }

  saveGoals() {
    const goals = this.goals.controls.map(ctrl => ctrl.value);

    this.goalsService.addGoals(goals, this.gameId)
      .pipe(take(1))
      .subscribe(_ => { this.router.navigate(['../..'], { relativeTo: this.route }) });
  }
}
