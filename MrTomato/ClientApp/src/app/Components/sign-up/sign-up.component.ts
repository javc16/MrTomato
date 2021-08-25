import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/Models/user.model';
import { UserService } from 'src/app/Services/User/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user:User=new User();
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  roles : any[];
  constructor(private _userService: UserService,private _router:Router,private _notifications:ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  OnSubmit()
  {
    if(this.user!==null)
    {
      this._userService.create(this.user).subscribe((data: any) =>{
        if(data.data.succeeded)
        {
          this.resetForm();
          this._notifications.success('New user created!', 'Registration successful.');        
        }else{
          data.data.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this._notifications.error('Username is already taken','Registration failed.');
                break;

              default:
              this._notifications.error(element.description,'Registration failed.');
                break;
            }
          });
        }
      })
    }
  }
  // crearEstadoTicket() {
  //   if (this.estadoTicket) {
  //     this._estadoTicketService.create(this.estadoTicket).subscribe(() => {
  //       this.router.navigate(['/estado-ticket']);
  //     });
  //   }
  // }
  resetForm(form?:NgForm)
  {
    if(form!=null){
      form.reset();
      this.user = {
        userName:'',
        password:'',
        email:'',
        firstName:'',
        lastName:'',
        name:'',
        role:''
      }
    }
   
  }
}
