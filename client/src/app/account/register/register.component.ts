import { Component, OnInit } from '@angular/core';
import { AsyncValidator, AsyncValidatorFn, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  loginForm: FormGroup;
  errors: string[];

  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit(): void {
    this.createregisterForm();
  }
  createregisterForm() {
    this.registerForm = new FormGroup({
      email: new FormControl(null, [
        Validators.required,
        Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$'),  
      ], [this.validateEmailNotTaken()]),
      password: new FormControl('', Validators.required),
      displayName: new FormControl('', Validators.required),
    });
  }
  onSubmit() {
    //console.log(this.loginForm.value);
    if (this.registerForm.valid) {
      this.accountService.register(this.registerForm.value).subscribe(
        () => {
          this.router.navigateByUrl('/shop');
        },
        (error) => {
          console.log(error);
          this.errors = error.errors
        }
      );
    }
  }

  validateEmailNotTaken(): AsyncValidatorFn{
    return control => {
      return timer(300).pipe(
        switchMap(() => {
          if(!control.value){
              return of(null);
          }
        
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? {emailExists : true} : null
            })
          )
        })
      )
    }
  }
}
