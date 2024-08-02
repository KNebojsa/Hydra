import { Component, EventEmitter, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  //-------------------------------------------------------------------------------------------------------------------------------------------
  //@Input() usersFromHomeComponent: any; //old way before 17.3 Angular (issue with not been requierd and not givving compile error)
  //usersFromHomeComponent = input.required<any>(); //new way 17.3 +
  // @Output() cancelRegister = new EventEmitter(); //old way before 17.3 Angular (issue with not been requierd and not givving compile error)
  //-------------------------------------------------------------------------------------------------------------------------------------------
  cancelRegister = output<boolean>();
  model: any = {};

  register() {
    this.accountService.register(this.model).subscribe({
      next: (response) => {
        console.log(response);
        this.cancel();
      },
      error: (error) => console.log(error),
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
