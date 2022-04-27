import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
  },
  {
    path: 'auth',
    component: AuthComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
//acum generam o componenta pe care sa facem ruta in modulul asta
