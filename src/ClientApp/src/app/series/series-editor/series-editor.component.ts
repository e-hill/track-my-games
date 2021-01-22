import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Game } from 'src/app/games/games.service';
import { SeriesService } from '../series.service';

@Component({
  selector: 'app-series-editor',
  templateUrl: './series-editor.component.html',
  styleUrls: ['./series-editor.component.scss']
})
export class SeriesEditorComponent implements OnInit {
  private seriesId: string;

  seriesName: string;
  games$: Observable<Game[]>;

  constructor(private seriesService: SeriesService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.seriesId = this.route.snapshot.paramMap.get('id');
    this.games$ = this.seriesService.getSeriesById(this.seriesId).pipe(map(s => s.games));
  }
}
