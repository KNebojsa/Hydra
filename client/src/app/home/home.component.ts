import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  registerMode = false;
  http = inject(HttpClient);
  users: any;

  ngOnInit(): void{
    this.getUsers();
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }
  
  cancelRegisterMode(event:boolean){
this.registerMode = event;
  }
  try(event:any){
    console.log('This works!!!' + event);
  }

  getUsers(){
    this.http.get("https://localhost:5001/api/Users").subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })
  }
}