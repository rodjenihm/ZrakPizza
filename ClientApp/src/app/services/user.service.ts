import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = "api/api/users";

  constructor(private http: HttpClient) { }

  create(user) {
    return this.http.post(this.url, user, { observe: 'response' })
      .pipe(
        map(response => {
          if (response.status === 201) return true;
          return false;
        })
      );
  }
}
