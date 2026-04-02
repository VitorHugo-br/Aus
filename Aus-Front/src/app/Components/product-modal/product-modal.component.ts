import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxPopupModule, DxFormModule, DxButtonModule, DxValidationGroupComponent } from 'devextreme-angular';
import { CreateProduct } from '../../Interfaces/create-product';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-product-modal',
  standalone: true,
  imports: [
    CommonModule,
    DxPopupModule,
    DxFormModule,
    DxButtonModule,
    DxValidationGroupComponent
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

    if (this.form?.instance) {
      this.form.instance.resetValues();
    }

    this.isVisible = true;
  }

  saveForm() {
    const validationResult = this.form.instance.validate();

    if (!validationResult.isValid) {
      notify('Por favor, preencha os campos corretamente', 'error', 3000)
      return;
    }

    this.onSave.emit(this.productData);
    this.isVisible = false;

  }

  closeModal() {
    this.isVisible = false;
  }

}
