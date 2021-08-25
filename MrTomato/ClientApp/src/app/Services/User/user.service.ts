import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { User } from 'src/app/Models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url:string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) 
  {
    this.url = baseUrl+ 'api/auth';
  }


  create(user: User) {
    user.name=user.firstName+' '+user.lastName;
    return this.http.post(this.url+'/register', user);
  }

  userAuthentication(user:string,password:string)
  {
    const body =
    {
      userName:user,
      Password:password
    }
    return this.http.post(this.url+'/login', body);
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    var userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole == element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
