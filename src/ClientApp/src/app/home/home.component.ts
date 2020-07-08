import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  onUpdate() {
    this.http.post<any>(this.baseUrl + 'api/psn', {})
      .subscribe(result => { }, error => console.error(error));
  }
}
