import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Product } from '../../Interfaces/product';
import { CreateProduct } from '../../Interfaces/create-product';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  private apiUrl = `${environment.apiUrl}/Product`;
  private token = sessionStorage.getItem('token');

  constructor(private http: HttpClient) { }

  async getProducts(): Promise<Product[]> {

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    var response: any = await firstValueFrom(
      this.http.get(this.apiUrl, { headers })
    );

    return response;
  }

  async getProductById(id: string): Promise<Product> {

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    var response: any = await firstValueFrom(
      this.http.get(this.apiUrl + `/${id}`, { headers })
    );

    return response;
  }

  async createProduct(product: CreateProduct) {

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    var response: any = await firstValueFrom(
      this.http.post(this.apiUrl, product, { headers })
    );

    return response;
  }

  async updateProduct(product: Product) {

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    var response: any = await firstValueFrom(
      this.http.patch(this.apiUrl + `/${product.id}`, product, { headers })
    );

    return response;
  }

  async deleteProduct(id: string) {

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });

    var response: any = await firstValueFrom(
      this.http.delete(this.apiUrl + `/${id}`, { headers })
    );

    return response;
  }
  
}
