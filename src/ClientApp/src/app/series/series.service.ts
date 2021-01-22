import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from '../games/games.service';

export class Series {
  name: string;
}

export class SeriesWithGames {
  games: Game[];
}

@Injectable({
  providedIn: 'root'
})
export class SeriesService {
  private url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.url = this.baseUrl + 'api/series';
  }

  getSeries(): Observable<Series[]> {
    return this.http.get<Series[]>(this.url);
  }

  addSeries(series: Series): Observable<Series> {
    return this.http.post<Series>(this.url, series);
  }

  getSeriesById(id: string): Observable<SeriesWithGames> {
    return this.http.get<SeriesWithGames>(this.url + '/' + id);
  }
}
