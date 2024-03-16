import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./security/authentication.module').then(m => m.AuthenticationModule)
  },
  {
    path: 'search',
    loadChildren: () => import('./text-source/text-source.module').then(m => m.TextSourceModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule]
})

export class AppRoutingModule { }
