import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../_models/user';
import { Observable } from 'rxjs';

<<<<<<< HEAD
=======
const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

>>>>>>> 3f2370d605989f1876e832d56d164d7c84eccd79
@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
<<<<<<< HEAD
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }
=======
    return this.http.get<User[]>(this.baseUrl + 'users', httpOptions );
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);
  }

>>>>>>> 3f2370d605989f1876e832d56d164d7c84eccd79
}
