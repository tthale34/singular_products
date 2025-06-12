import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Product } from './product.model';
import { SalesReport } from './sales.report.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url: string = environment.apiBaseUrl + '/Products'
  urlSales: string = environment.apiBaseUrl + '/SalesReport'
  list: Product[] = [];
  listSalesReport: SalesReport[] = [];
  formData: Product = new Product();
  formSubmitted: boolean=false;

  constructor(private http: HttpClient) { }
  //Read Products
  getProductList(){
    this.http.get(this.url)
    .subscribe({
      next: result => {
        this.list = result as Product[];
      },
      error: err => { console.log(err) }
    }
    );
  }
  //Read Sales Report
  getSalesReport(){
    this.http.get(this.urlSales)
    .subscribe({
      next: result => {
        this.listSalesReport = result as SalesReport[];
      },
      error: err => { console.log(err) }
    }
    );
  }

}

