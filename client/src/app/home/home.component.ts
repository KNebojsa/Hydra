import { Component } from '@angular/core';
import { TranslateService, TranslateModule } from '@ngx-translate/core';
import { RegisterComponent } from '../register/register.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TranslateModule, CommonModule, RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  registerMode = false;
  profileImagePath = 'assets/images/profile.jpg';
  currentLang: string;

  constructor(private translate: TranslateService) {
    this.currentLang = 'en';
    translate.setDefaultLang('en');
    translate.use('en');
  }

  switchLanguage(lang: string) {
    this.currentLang = lang;
    this.translate.use(lang);
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = false;
  }

  showRegisterForm() {
    this.registerMode = true;
  }
}
