import { Component } from '@angular/core';
import { RegisterUserDto } from '../auth.model';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerModel: RegisterUserDto = { username: '', email: '', firstName: '', lastName: '', password: '', role: 'User' };
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  register() {
    this.authService.register(this.registerModel).subscribe(
      response => {
      },
      error => {
        if (error.status === 400) {
          this.errorMessage = 'Registration failed. Please try again.';
        } else if (error.status === 200) {
          this.router.navigate(['/login']);
        } else {
          this.errorMessage = 'An error occurred. Please try again later.';
        }
      }
    );
  }
}
