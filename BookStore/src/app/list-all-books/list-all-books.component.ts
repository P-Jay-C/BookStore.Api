import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-list-all-books',
  templateUrl: './list-all-books.component.html',
  styleUrls: ['./list-all-books.component.css']
})
export class ListAllBooksComponent implements OnInit  {
  constructor(private service: BookService) {
  }
  ngOnInit(): void {
    this.getBooks();
  }

  public books: any;

  public getBooks():void{
    this.service.getBooks().subscribe(data=>{
      this.books = data;
    })
  }
}
