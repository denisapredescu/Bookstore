import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-modity-author',
  templateUrl: './modity-author.component.html',
  styleUrls: ['./modity-author.component.scss']
})
export class ModityAuthorComponent implements OnInit {

  public authorForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
  });

  public title;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private authorService: AuthorService,
    public dialogRef: MatDialogRef<ModityAuthorComponent>,
  ) {
    
    if (data.author) {
      this.title = 'Edit author';
      this.authorForm.patchValue(this.data.author);
    } 
    else {
      this.title = 'Add author';
    }
  }

  ngOnInit() {
  }

  public add(): void{

    this.authorService.AddAuthor(this.authorForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

  public edit(): void{

    this.authorService.UpdateAuthor(this.authorForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }
}

