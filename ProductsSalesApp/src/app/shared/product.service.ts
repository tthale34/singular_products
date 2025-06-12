import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Product } from './product.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url: string = environment.apiBaseUrl + '/Products'
  list: Product[] = [];
  formData: Product = new Product();
  formSubmitted: boolean=false;

  constructor(private http: HttpClient) { }
  //Read Products
  getProductList(){
    console.log(this.url);
    this.http.get(this.url)
    .subscribe({
      next: result => {
        this.list = result as Product[];
        console.log("in get product list");
        console.log(this.list);
      },
      error: err => { console.log(err) }
    }
    );
  }

}
