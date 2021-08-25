import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/Services/User/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  /**
   *
   */
  constructor(private router:Router, private _userService:UserService) {
      
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean  {
      if(localStorage.getItem('token') != null )
      {
        let roles = next.data['permittedRoles'] as Array<string>;
        if(roles){
          if(this._userService.roleMatch(roles))
          {
            return true;
          }else
          {
            
            this.router.navigate(['/forbidden'])
          }
        }
        return true;
      }
    
    else
    debugger;
    this.router.navigate(['/forbidden'])
    return false;
  }
  
}
