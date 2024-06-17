import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'TeraClient';
  users: any; // can be of any type
  constructor(private http: HttpClient) { }
  ngOnInit(): void 
  {
    this.http.get('https://localhost:5248').subscribe({
      next: response => this.users = response,    //we wanto assign this response to users variable
      error: error => console.log(error),
      complete: () => console.log('Request has completed') //because this is http request it will always complete
    })
  }
  
}
