import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { BasketComponent } from './modules/basket/basket.component';
import { OrderComponent } from './modules/order/order.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'auth',
  },
  {
    path: 'auth',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'books',
    loadChildren: () => import('src/app/modules/books/books.module').then(m => m.BooksModule),
  },

  {
    path: 'basket/:email',
    canActivate: [AuthGuard],
    component: BasketComponent
  },

  {
    path: 'orders/:email',
    canActivate: [AuthGuard],
    component: OrderComponent
  },

];

//acum facem o ruta pentru modulul creat

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
