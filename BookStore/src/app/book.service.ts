import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private basePath = "https://localhost:7213/api/Books";
  constructor(private httpClient: HttpClient) {}

  public getBooks():Observable<any> {
    return this.httpClient.get(this.basePath);
  }

  public AddBook(book:any):Observable<any> {
    return this.httpClient.post(this.basePath,book);
  }
}
