import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { endpoint } from '../../shared/apis/endpoint';
import { BaseResponse, Baseentity } from '../../commons/Basegeneral';
import { ProductResponseDto } from '../../commons/ProductBase';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private _http: HttpClient,) { }


  ListProduct(): Observable<BaseResponse<Baseentity<ProductResponseDto[]>>> {

    const request = `${environment.api}${endpoint.Mostrar_product}`

    return this._http.get<BaseResponse<Baseentity<ProductResponseDto[]>>>(request);
  }


  ProductID(id:number):Observable<BaseResponse<ProductResponseDto>> {
    const request = `${environment.api}${endpoint.PRODUCT_ID}${id}`

    return this._http.get<BaseResponse<ProductResponseDto>>(request);
  }









}
