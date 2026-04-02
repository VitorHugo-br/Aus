import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LoginResponse } from '../../Interfaces/login-response';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private apiUrl = `${environment.apiUrl}/Auth/login`;

  constructor(private http: HttpClient) { }

  async authorize(username: string, password: string): Promise<boolean> {
    try {
      const response = await firstValueFrom(
        this.http.post<LoginResponse>(this.apiUrl, { username, password })
      );

      if (response && response.token) {
        sessionStorage.setItem('token', response.token);
        return true;
      } else {
        return false;
      }
    } catch (error) {
      return false;
    }
  }

  isLoggedIn(): boolean {
    return !!sessionStorage.getItem('token');
  }

}