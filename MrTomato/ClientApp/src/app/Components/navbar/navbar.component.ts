import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  readLocalStorageValue(key) {
    return localStorage.getItem(key);
  }

  removeLocalStorageValue(key) {
    return localStorage.removeItem(key); 
  } 
}
