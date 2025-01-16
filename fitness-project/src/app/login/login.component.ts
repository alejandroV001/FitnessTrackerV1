import { Component } from '@angular/core';
import { LoginUserDto } from '../auth.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginModel: LoginUserDto = { username: '', password: '', rememberMe: false };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.loginModel).subscribe(
      response => {
        this.router.navigate(['/dashboard']);
      },
      error => {
        if (error.status === 404) {
          this.errorMessage = 'User does not exist. Please check your credentials.';
        } else {
          this.errorMessage = 'An error occurred. Please try again later.';
        }
      }
    );
  }
}
