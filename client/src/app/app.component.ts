import { HttpClient,  } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'Linkup App';
  users:any;


  ngOnInit(): void {
    this.http.get('https://localhost:5002/api/users').
    subscribe({
      next: data => this.users = data,
      error: error => console.error('There was an error!', error),
      complete: () => console.log('Completed')
    })
  }
}
