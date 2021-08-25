import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "./Components/Auth/auth.guard";
import { CategoryComponent } from "./Components/category/category.component";
import { ForbiddenComponent } from "./Components/forbidden/forbidden.component";
import { SignInComponent } from "./Components/sign-in/sign-in.component";
import { SignUpComponent } from "./Components/sign-up/sign-up.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { HomeComponent } from "./home/home.component";

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
    {
      path: 'categories',
      component: CategoryComponent,
      canActivate:[AuthGuard],
      data:{permittedRoles:['Admin']}
    }, 
    {
      path: 'sign-up',
      component: SignUpComponent,
      canActivate:[AuthGuard],
      data:{permittedRoles:['Admin']}
    },
    {
      path: 'sign-in',
      component: SignInComponent,
    },
    {
      path: 'forbidden',
      component: ForbiddenComponent,
    },   
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {  }
  