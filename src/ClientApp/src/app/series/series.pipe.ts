import { Pipe, PipeTransform } from '@angular/core';
import { Series } from './series.service';

@Pipe({
  name: 'filterOnName'
})
export class FilterOnNamePipe implements PipeTransform {

  transform(series: Series[], substring: string) {
    return series && series.filter(series => !series.name || series.name.toLowerCase().startsWith(substring));
  }

}
