import { Component, OnInit } from '@angular/core';
import { SeriesService, Series } from './series.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-series',
  templateUrl: './series.component.html',
  styleUrls: ['./series.component.scss']
})
export class SeriesComponent implements OnInit {
  series$: Observable<Series[]>;

  constructor(private seriesService: SeriesService) { }

  ngOnInit(): void {
    this.series$ = this.seriesService.getSeries().pipe(
      tap(series => {
        series.sort((a, b) => {
          if (a.name > b.name) return 1;
          else if (a.name < b.name) return -1;
          else return 0;
        });
      })
    );
  }

}
