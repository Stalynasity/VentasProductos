import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListTableComponent } from './list-table/list-table.component';
import { SharedModule } from '../../shared/shared.module';
import { RouterLinkActive } from '@angular/router';



@NgModule({
  declarations: [
    ListTableComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterLinkActive
  ],
  exports: [
    ListTableComponent
  ]
})
export class ProductModule { }
