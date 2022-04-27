import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AuthorInfo } from 'src/app/interfaces/author-info';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-author-details',
  templateUrl: './author-details.component.html',
  styleUrls: ['./author-details.component.scss']
})
export class AuthorDetailsComponent implements OnInit {

  public title: string = "Details"
  public authorInfo: AuthorInfo ={
    nationality: 'unknown',
    birthYear: 0,
    deathYear: 0,
  };

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private authorService: AuthorService,
    public dialogRef: MatDialogRef<AuthorDetailsComponent>,
  ) { }
 

  ngOnInit() {

    this.authorService.GetAuthorInfo(this.data.id).subscribe(
      (response) =>{
          this.authorInfo = response;
        console.log(this.authorInfo);
        if(this.authorInfo.nationality === null && this.authorInfo.birthYear === null && this.authorInfo.deathYear === null)
        {
          this.title = 'There are no details!';
        }
      },  
      (error)=>{
        console.error(error);
        
      });
  }

}  

