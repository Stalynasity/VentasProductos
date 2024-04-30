import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './page/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'notfound',
  },
  {
    path: 'product',
    loadChildren: () =>
      import('./page/product/product.module').then((m) => m.ProductModule),
  },
  {
    path: 'notfound', component: NotFoundComponent
  },
  {
    path: '**',
    redirectTo: 'notfound',
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
