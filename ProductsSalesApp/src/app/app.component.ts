import { Component, OnInit } from '@angular/core';
import { ProductService } from './shared/product.service';
import { Product } from './shared/product.model';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(public service : ProductService,private toastr:ToastrService){
  
    }
  ngOnInit(): void {
    this.service.getProductList();
  }
  title = 'Products & Reports APP';
}
