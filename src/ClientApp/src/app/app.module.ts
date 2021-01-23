import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';
import { PsnComponent } from './psn/psn.component';
import { PsnGameDetailComponent } from './psn/psn-game-detail/psn-game-detail.component';
import { GameGeneratorComponent } from './games/game-generator/game-generator.component';
import { GoalsComponent } from './games/goals/goals.component';
import { GameEditorComponent } from './games/game-editor/game-editor.component';
import { FilterOnNamePipe } from './games/games.pipe';
import { SeriesComponent } from './series/series.component';
import { SeriesGeneratorComponent } from './series/series-generator/series-generator.component';
import { SeriesEditorComponent } from './series/series-editor/series-editor.component';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { AppEffects } from './state/games.effects';
import { gamesReducer } from './state/games.reducer';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GamesComponent,
    PsnComponent,
    PsnGameDetailComponent,
    GameGeneratorComponent,
    GoalsComponent,
    GameEditorComponent,
    FilterOnNamePipe,
    SeriesComponent,
    SeriesGeneratorComponent,
    SeriesEditorComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    StoreModule.forRoot({ games: gamesReducer }),
    StoreDevtoolsModule.instrument({ maxAge: 25, }),
    EffectsModule.forRoot([AppEffects]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
