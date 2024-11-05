import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  standalone: true,
  imports: [],
  templateUrl: './test-errors.component.html',
  styleUrl: './test-errors.component.css',
})
export class TestErrorsComponent {
  private http = inject(HttpClient);
  validationErrors: string[] = [];

  get400Error() {
    return this.http
      .get('https://localhost:5001/api/buggy/bad-request')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get401Error() {
    return this.http.get('https://localhost:5001/api/buggy/auth').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.error(error),
    });
  }

  get404Error() {
    this.get400Error();
    return this.http
      .get('https://localhost:5001/api/buggy/not-found')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get500Error() {
    return this.http
      .get('https://localhost:5001/api/buggy/server-error')
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => console.error(error),
      });
  }

  get400ValidationError() {
    return this.http
      .post('https://localhost:5001/api/account/register', {})
      .subscribe({
        next: (response) => console.log(response),
        error: (error) => {
          console.error(error);
          this.validationErrors = error;
        },
      });
  }
}
