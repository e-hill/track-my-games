import { Pipe, PipeTransform } from '@angular/core';
import { Game } from './games.service';

@Pipe({
  name: 'filterOnName'
})
export class FilterOnNamePipe implements PipeTransform {

  transform(games: Game[], substring: string) {
    return games && games.filter(game => !game.name || this.startsWith(game.name, substring));
  }

  private startsWith(string1: string, string2: string) {
    return string1.toLowerCase().startsWith(string2.toLowerCase());
  }

}
