import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';
import { PsnComponent } from './psn/psn.component';
import { PsnGameDetailComponent } from './psn/psn-game-detail/psn-game-detail.component';
import { GameGeneratorComponent } from './games/game-generator/game-generator.component';
import { GoalsComponent } from './games/goals/goals.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'games', component: GamesComponent },
  { path: 'games/create', component: GameGeneratorComponent },
  { path: 'games/:id/goals', component: GoalsComponent },
  { path: 'psn', component: PsnComponent },
  { path: 'psn/:id', component: PsnGameDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
