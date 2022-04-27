import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-modity-book',
  templateUrl: './modity-book.component.html',
  styleUrls: ['./modity-book.component.scss']
})

export class ModityBookComponent implements OnInit {

  public bookForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    price: new FormControl(0),
    noPages: new FormControl(0),
    year: new FormControl(0),
    noVolume: new FormControl(0),
    seriesName: new FormControl(''),
  });


  public title;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private bookService: BookService,
    public dialogRef: MatDialogRef<ModityBookComponent>,
  ) {
    console.log(this.data);
    if (data.book) {
      this.title = 'Edit book';
      this.bookForm.patchValue(this.data.book);
    } else {
      this.title = 'Add book';
    }
  }


  ngOnInit() {
  }

  public add(): void {
    console.log(this.bookForm.value);

    this.bookService.addBook(this.bookForm.value).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public edit(): void {
    this.bookService.updateBook(this.bookForm.value).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

}