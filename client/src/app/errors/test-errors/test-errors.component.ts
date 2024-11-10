import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-test-errors',
  standalone: true,
  imports: [],
  templateUrl: './test-errors.component.html',
  styleUrl: './test-errors.component.css',
})
export class TestErrorsComponent {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  validationErrors: string[] = [];

  get400Error() {
    return this.http
      .get(this.baseUrl + 'buggy/bad-request')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get401Error() {
    return this.http.get(this.baseUrl + 'buggy/auth').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.error(error),
    });
  }

  get404Error() {
    this.get400Error();
    return this.http
      .get(this.baseUrl + 'buggy/not-found')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get500Error() {
    return this.http
      .get(this.baseUrl + 'buggy/server-error')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get400ValidationError() {
    return this.http
      .post(this.baseUrl + 'account/register', {})
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => {
          console.error(error);
          this.validationErrors = error;
        },
      });
  }
}
