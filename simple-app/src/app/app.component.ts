import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  todos$: Observable<any>;
  constructor(private http: HttpClient) {
    this.todos$ = new Observable();
  }
  ngOnInit(): void {
    this.getTodos();
  }
  getTodos() {
    this.todos$ = this.http.get(this.url)
  }

  readonly url = "https://localhost:7077/todo"
  obj = { todo: '' };

  save() {
    this.http.post(this.url, this.obj, { responseType: 'text' })
      .subscribe(res => {
        console.log(res)
        this.obj.todo = ''
        this.getTodos();
      });
  }
}
