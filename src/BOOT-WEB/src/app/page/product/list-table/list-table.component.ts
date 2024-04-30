import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { ProductResponseDto } from '../../../commons/ProductBase';

@Component({
  selector: 'app-list-table',
  templateUrl: './list-table.component.html',
  styleUrl: './list-table.component.css'
})
export class ListTableComponent implements OnInit {

  constructor(
    private Httproduct: ProductService
  ){  }

  listProduct: ProductResponseDto[] = [];

  generar(){
    this.Httproduct.ListProduct().subscribe(e => {
      this.listProduct = e.Data.items;
    })
  }

  addToCart(product: number){

  }



  ngOnInit(): void {
    this.generar();
  }





}
