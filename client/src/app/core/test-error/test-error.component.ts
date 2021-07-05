import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss'],
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors : any;
  constructor(private htpp: HttpClient) {}

  ngOnInit(): void {}

  getError404() {
    this.htpp.get(this.baseUrl + 'product/42').subscribe(response => {
      console.log('response '+response);
    }, error => {
      console.log( error);
      
    });
  }

  getError500() {
    this.htpp.get(this.baseUrl + 'buggy/servererror').subscribe(response => {
      console.log('response '+response);
    }, error => {
      console.log( error);
    });
  }

  getError400() {
    this.htpp.get(this.baseUrl + 'buggy/badrequest').subscribe(response => {
      console.log('response '+response);
    }, error => {
      console.log(error); 
    });
  }

  getError400Validation() {
    this.htpp.get(this.baseUrl + 'product/fortytwo').subscribe(response => {
      console.log('response '+response);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }
  
}
