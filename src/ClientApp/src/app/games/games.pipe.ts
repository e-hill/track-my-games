import { Pipe, PipeTransform } from '@angular/core';
import { Game } from './games.service';

@Pipe({
  name: 'filterOnName'
})
export class FilterOnNamePipe implements PipeTransform {

  transform(games: Game[], substring: string) {
    return games && games.filter(game => !game.name || game.name.toLowerCase().startsWith(substring));
  }

}
