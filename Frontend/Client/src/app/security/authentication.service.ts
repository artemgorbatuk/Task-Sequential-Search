import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginFilter } from './login/login-filter.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private loginUrl = 'http://localhost:54414/Authentication/Login';
  constructor(private http: HttpClient) { }

  login(userName: string, password: string): Observable<any> {
    const filter = new LoginFilter(userName, password);
    return this.http.post(this.loginUrl, filter);
  }

  logout(): void {
    localStorage.removeItem("token");
  }

  isUserLoggedIn(): boolean {
    return localStorage.getItem("token") != null;
  }
}
