import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBookComponent } from './add-book/add-book.component';
import { ListAllBooksComponent } from './list-all-books/list-all-books.component';

const routes: Routes = [
  {path:'books', component:ListAllBooksComponent},
  {path:'add-book', component:AddBookComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
