import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = 'api/api/authenticate';

  constructor(private http: HttpClient) { }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    if (!token) return false;
    const jwtHelper = new JwtHelperService();
    return !jwtHelper.isTokenExpired(token);
  }

  authenticate(credentials): Observable<boolean> {
    return this.http.post(this.url, credentials, { observe: 'body' })
      .pipe(
        map((body) => {
          if (body && body['token']) {
            localStorage.setItem('token', body['token']);
            return true;
          };
          return false;
        })
      );
  }

  deauthenticate() {
    localStorage.removeItem('token');
  }

  get currentUser() {
    const token = localStorage.getItem('token');
    if (!token) return null;
    const jwtHelper = new JwtHelperService();
    return jwtHelper.decodeToken(token);
  }
}
