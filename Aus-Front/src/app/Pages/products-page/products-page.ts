import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../../Services/products/product-service';
import { DxDataGridModule, DxButtonModule, DxDataGridComponent } from 'devextreme-angular';
import { Product } from '../../Interfaces/product';
import { ProductModalComponent } from '../../Components/product-modal/product-modal.component';
import { CreateProduct } from '../../Interfaces/create-product';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-products-page',
  imports: [DxDataGridModule, DxButtonModule, ProductModalComponent],
  templateUrl: './products-page.html',
  styleUrl: './products-page.css',
})
export class ProductsPage implements OnInit {
  
  @ViewChild(ProductModalComponent) productModal!: ProductModalComponent;

  private productService = inject(ProductService);
  products: Product[] = [];
  
  
  ngOnInit(): void {
    this.loadProducts();
  }
  
  loadProducts() {
    this.productService.getProducts().then(response => {
      this.products = response;
    });
  }

  onAddProduct() {
    this.productModal.openModal();
  }

  onSaveProduct(product: CreateProduct) {
    this.productService.createProduct(product)
      .then(() => {
        notify('Produto criado com sucesso!', 'success', 3000);
        this.loadProducts();
      })
      .catch(err => {
        console.error('Erro ao criar produto', err);
        notify('Erro ao criar produto.', 'error', 3000);
      });
  }

  onRowUpdating(e: any) {
    const updatedProduct = { ...e.oldData, ...e.newData };

    e.cancel = new Promise<boolean>((resolve, reject) => {
      this.productService.updateProduct(updatedProduct)
        .then(() => resolve(false))
        .catch(err => {
          console.error('Erro ao atualizar', err);
          alert('Erro ao atualizar produto.');
          reject(true);
        });
    });
  }

  onRowRemoving(e: any) {
    const product: Product = e.data;

    e.cancel = new Promise<boolean>((resolve, reject) => {
      this.productService.deleteProduct(product.id)
        .then(() => resolve(false))
        .catch(err => {
          console.error('Erro ao deletar', err);
          alert('Erro ao excluir produto.');
          reject(true);
        });
    });
  }

}
