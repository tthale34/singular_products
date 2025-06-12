import { Component, NgModule, OnInit } from '@angular/core';
import { ProductService } from './shared/product.service';
import { Product } from './shared/product.model';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Products & Reports APP';

  showProducts: boolean = true;
  modelFrom: { year: number; month: number; day: number; } | undefined;
  modelTo: { year: number; month: number; day: number; } | undefined;

  constructor(public service : ProductService,private toastr:ToastrService){
  
    }
  ngOnInit(): void {
    this.service.getProductList();
    this.service.getSalesReport();
  }
  toggleLabel() {
    this.showProducts = !this.showProducts;
  }

  showProductsView() {
    this.showProducts = true;
  }

  showSalesView() {
    this.showProducts = false;
  }
}
