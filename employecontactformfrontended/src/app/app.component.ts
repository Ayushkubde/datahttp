import { Component } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { AppRoutingModule } from './app-routing.module';
import { error } from '@angular/compiler/src/util';
import { Subscriber } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public employe_id: number = 1;
  public employename: string = '';
  public designation: string = '';
  public salary: number = 0;
  public email: string = '';
  public mobile: number = 0;
  public qualification: string = '';
  public manager: string = '';
  output: any;
  status: any;
  errormessage: any;
  HttpClient: any;

  readonly url = "https://localhost:44323/api/valuescontroller/";
  constructor(private http: HttpClient) { }
  

  public update() {
    let updatedatas = { employename: this.employename, designation: this.designation, salary: this.salary, email: this.email, mobile: this.mobile, qualification: this.qualification, manager: this.manager };
    this.http.put<any>(this.url + this.employe_id, updatedatas).subscribe({
      next: data => {
        this.status = "data successfully update ";
        console.log("Data is successfully updated");
      },
      error: error => {
        this.errormessage = error.message;
        console.log("there was an error on updating statment");
      }
    });
  }
  public reset() {
    this.output = this.http.get(this.url);
  }
  public edit(item: any) {
    this.employe_id = item.employe_id;
    this.employename = item.employename;
    this.designation = item.designation;
    this.salary = item.salary;
    this.email = item.email;
    this.mobile = item.mobile;
    this.qualification = item.qualification;
    this.manager = item.manager;
  }

  public delete(employe_id: any) {
    this.http.delete<any>(this.url + employe_id).subscribe({
      next: data => {
        this.status = "delete successfull";
        console.log("data is successfully deleted");
        this.output = this.http.get(this.url);
      },
      error: error => {
        this.errormessage = error.message;
        console.log("There was an error in deleteing the data for given context");
      }
    });
  }

}





