import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BookBasket } from 'src/app/interfaces/book-basket';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  public message: string  = "";
  public email: string = '';
  public displayedColumns = ['name', 'price', 'noCopiesInBasket', 'priceOfNoCopies', 'plus', 'minus'];
  public totalPrice: string = '';
  public bookbasket: BookBasket[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private basketService: BasketService,
    private route: Router,
    ) {}

  ngOnInit(): void {

    //pentru ruta cu parametru
    this.activatedRoute.params.subscribe((params: any) => {
      console.log('param', params);
      this.email = params['email'];
    });
  
    console.log(this.email);
    this.basketService.GetBookBasketForUser(this.email).subscribe(
      (response)=>{
        this.bookbasket = response;
        this.condition();
      },
      (error)=>{
        console.error(error);
      });

  }

  public condition(): void{    //in functie de ce se intampla aici, se afiseaza un mesaj sau un tabel cu cartile din cos
    console.log('here', this.bookbasket);
    if(!this.bookbasket.length)
    {
      console.log("intra");
      this.displayedColumns = [];
      this.message = "There are no books in basket!";
      this.totalPrice = '';
    }
    else
      this.getPrice();
  }

  public plus(bookbasket): void{
    this.basketService.IncreaseNoCopies(bookbasket).subscribe(
      (response)=>{
        this.bookbasket=response;
        this.getPrice();
      },
      (error)=>{
        console.error(error);
      });
  }

  public minus(bookbasket): void{
    this.basketService.DecreaseNoCopies(bookbasket).subscribe(
      (response)=>{
        this.bookbasket=response;
        this.condition();
      },
      (error)=>{
        console.error(error);
      });
  }

  public delete(): void{
    this.basketService.DeleteAllBookBasketByEmail(this.email).subscribe(
      (response)=>{
        this.bookbasket=[];
        this.condition();
      },
      (error)=>{
        console.error(error);
      });
  }

  //toate cartile din cos fac parte din acelasi cos, asa ca nu conteaza din care iau id ul
  //se trateaza in functia condition() daca nu am nicio carte in cos
  public getPrice(): void{
    console.log(this.bookbasket);

    this.basketService.BasketPrice(this.bookbasket[0].basketId).subscribe(  
      (response)=>{
        this.totalPrice = response.price;
      },
      (error)=>{
        console.error(error);
      }
    );
  }

  public makeOrder(): void{
    this.basketService.UpdateSentBasket(this.email).subscribe(
      (response)=>{
        console.log("s-a facut comanda");
        this.bookbasket = [];
        this.condition();  
      },
      (error)=>{
        console.error(error);
      })

  }

  public goBack(): void{
    this.route.navigate(['/books']);
  }

}
