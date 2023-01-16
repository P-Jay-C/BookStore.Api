import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  constructor(
    private formBuilder:FormBuilder,
    private bookService: BookService){
  }

  ngOnInit(): void {
    this.bookForm = this.formBuilder.group({
      title:[],
      description:[]
    })
  }

  public bookForm:any;

  public AddBook(){
    this.bookService.AddBook(this.bookForm.value).subscribe(result=>{
      alert('New book added')
    })
  }

}
