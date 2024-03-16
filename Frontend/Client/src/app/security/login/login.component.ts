import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public userName!: string;
  public password!: string;
  constructor(private authenticationService: AuthenticationService) { }

  public login(userName: string, password: string) {
    this.authenticationService.login(userName, password).subscribe({
      next: (data) => {
        localStorage.setItem('access_token', data.access_token);
        // Перенаправьте пользователя на главную страницу или другую страницу
      },
      error: (error) => {
        // Обработка ошибки
        console.log(error)
      }
    });
  }
}
