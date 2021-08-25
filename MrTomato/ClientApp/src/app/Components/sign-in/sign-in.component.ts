import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/Services/User/user.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError : boolean = false;
  constructor(private userService : UserService,private router : Router,private _notifications:ToastrService) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null )
    this.router.navigateByUrl('');
  }

  OnSubmit(userName,password){
     this.userService.userAuthentication(userName,password).subscribe((data : any)=>{
       if(data.status ==='Failed')
       {
         debugger;
        this._notifications.error(data.message,'Registration failed.');
       }else
       {
        localStorage.setItem('token',data.data);
        localStorage.setItem('userRoles',data.role);
        this.router.navigate(['']);  
       }
 
    });
  }

}
