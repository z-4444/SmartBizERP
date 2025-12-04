import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, AbstractControl, ValidationErrors } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  registerForm: FormGroup;
  errorMessage: string | null = null;
  showPassword = false;
  showConfirmPassword = false;
  isLoading = false;

  constructor(private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router) {
    this.registerForm = this.formBuilder.group({
      fullName: ['', [Validators.required], [Validators.minLength(3), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8), this.passwordStrengthValidator]],
      confirmPassword: ['', [Validators.required]],
      agreeToTerms: [false, [Validators.requiredTrue]]
    }, {
      validators: [this.passwordMatchValidator]
    })
  }

  get fullName() {
    return this.registerForm.get('fullName');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  get agreeToTerms() {
    return this.registerForm.get('agreeToTerms');
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  toggleConfirmPasswordVisibility() {
    this.showConfirmPassword = !this.showConfirmPassword;
  }

  onSubmit() {
    if (this.registerForm.valid) {
      this.isLoading = true;
      this.errorMessage = null;
      this.authService.register(this.registerForm.value).subscribe({
        next: (response) => {
          this.isLoading = false;
          this.router.navigate(['/login'])
        },
        error: (error) => {
          this.isLoading = false;
          this.errorMessage = error.error.message;
        }
      })
    } else {
      this.markFormGroupTouched(this.registerForm);
    }
  }

  private markFormGroupTouched(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(key => {
      const control = formGroup.get(key);
      control?.markAsTouched();
    });
  }

  passwordStrengthValidator(control: AbstractControl): ValidationErrors | null {
    const value = control.value;
    if (!value) return null;

    const hasNumber = /[0-9]/.test(value);
    const hasUpper = /[A-Z]/.test(value);
    const hasLower = /[a-z]/.test(value);

    const passwordValid = hasNumber && hasUpper && hasLower;

    return !passwordValid ? { passwordStrength: true } : null;
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (!password || !confirmPassword) return null;

    return password.value === confirmPassword.value ? null : { passwordMismatch: true };
  }
}
