import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxPopupModule, DxFormModule, DxButtonModule } from 'devextreme-angular';
import { CreateProduct } from '../../Interfaces/create-product';

@Component({
  selector: 'app-product-modal',
  standalone: true,
  imports: [
    CommonModule,
    DxPopupModule,
    DxFormModule,
    DxButtonModule
  ],
  templateUrl: './product-modal.component.html',
  styleUrls: ['./product-modal.component.css']
})
export class ProductModalComponent {
  @Output() onSave = new EventEmitter<CreateProduct>();

  isVisible = false;
  productData: CreateProduct = {
    productName: '',
    productDescription: '',
    productPrice: 0,
    productQuantity: 0
  };

  @ViewChild('form', { static: false }) form: any;

  openModal() {
    this.productData = {
      productName: '',
      productDescription: '',
      productPrice: 0,
      productQuantity: 0
    };
    this.isVisible = true;
  }

  saveForm() {
    this.onSave.emit(this.productData);
    this.isVisible = false;
  }

  closeModal() {
    this.isVisible = false;
  }
}
