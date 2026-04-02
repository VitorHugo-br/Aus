import { Component, inject, ViewChild } from '@angular/core';
import { DxFormComponent, DxFormModule } from 'devextreme-angular';
import { AuthService } from '../../Services/auth/auth-service';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-login-page',
  imports: [DxFormModule],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css',
})
export class LoginPage {

  private authService = inject(AuthService);
  private router = inject(Router);

  @ViewChild(DxFormComponent) form!: DxFormComponent;

  formData = {
    username: '',
    password: ''
  };

  loginButton = {
    text: 'Entrar',
    type: 'default',
    width: '100%',
    onClick: () => this.onLogin(),
  };

  async onLogin() {
    const result = this.form.instance.validate();
    if (!result.isValid) return;

    try {

      var response = await this.authService.authorize(this.formData.username, this.formData.password);
      if (response) {
        this.showToastSuccess();
        this.router.navigate(['/products']);
      } else {
        this.showToastError();
      }

    } catch (error) {
      throw error;
    }
  }

  showToastSuccess() {
    notify(
      {
        message: "Login realizado com sucesso!",
        width: 230,
        position: {
          at: 'bottom',
          my: 'bottom',
          of: window
        }
      },
      'success',
      500
    );
  }

  showToastError() {
    notify(
      {
        message: "Erro ao realizar login, verifique suas credenciais!",
        width: 230,
        position: {
          at: 'bottom',
          my: 'bottom',
          of: window
        }
      },
      'error',
      500
    );
  }


}
