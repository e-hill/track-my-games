import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class Series {
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class SeriesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getSeries(): Observable<Series[]> {
    return this.http.get<Series[]>(this.baseUrl + 'api/series');
  }

  addSeries(series: Series): Observable<Series> {
    return this.http.post<Series>(this.baseUrl + 'api/series', series);
  }
}
