import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BasketService } from 'src/app/services/basket.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  public index : number = 1;
  public test: string = "ana mere <br>";
  public email: string = '';
  public orders: string[];
  constructor(
    private activatedRoute: ActivatedRoute,
    private basketService: BasketService,
    private route: Router
  ) { }

  ngOnInit() {
    //pentru ruta cu parametru
    this.activatedRoute.params.subscribe((params: any) => {
      console.log('param', params);
      this.email = params['email'];
    });

    console.log(this.email);
    this.basketService.GetStringBookBasket(this.email).subscribe(
      (response) => {
        console.log(response);
        this.orders =  response;
      },
      (error)=>{
        console.error(error);
      });
  }

  public goBack(): void{
    this.route.navigate(['/books']);
  }
}
