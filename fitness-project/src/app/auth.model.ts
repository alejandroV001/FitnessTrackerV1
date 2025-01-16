export interface RegisterUserDto {
    username: string;
    email: string;
    firstName: string;
    lastName: string;
    password: string;
    role: string;
  }
  
  export interface LoginUserDto {
    username: string;
    password: string;
    rememberMe: boolean;
  }
  