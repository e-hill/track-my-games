import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { SeriesService, Series } from '../series.service';
import { Router, ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-series-generator',
  templateUrl: './series-generator.component.html',
  styleUrls: ['./series-generator.component.scss']
})
export class SeriesGeneratorComponent implements OnInit {
  seriesForm: FormGroup;

  constructor(private seriesService: SeriesService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.seriesForm = this.fb.group({
      name: this.fb.control('', Validators.required),
    });
  }

  onSubmit() {
    var series = new Series();
    series.name = this.seriesForm.get('name').value;

    this.seriesService.addSeries(series)
      .pipe(take(1))
      .subscribe(_ => { this.router.navigate(['..'], { relativeTo: this.route }) });
  }
}
