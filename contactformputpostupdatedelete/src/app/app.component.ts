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
  public name: string = '';
  public course: string = '';
  public id: number = 1;
  public updatename: string = '';
  public updatecourse: string = '';
  public check: Array<any> = [];
  readonly URL = 'https://localhost:44324/api/valuescontroller/';
  studentdetails: any;
  addspost: any;
  errormessage: any;
  httpClient: any;
  datas: any;
  successmessage: any;
  status: any;

  constructor(private http: HttpClient) { }

  public getPosts() {
    this.studentdetails = this.http.get(this.URL);

  }
  public addpost() {
    let data = { name: this.name, course: this.course };
    this.http.post<any>(this.URL, data).subscribe({

      next: data => {
        this.status = "data is successfully inserted";
        console.log("data is succefully inserted");

      },
      error: error => {
        this.errormessage = error.message;
        console.error("there was an error", error);
      }
    });
  }
  public update() {
    let updatedatas = { name: this.updatename, course: this.updatecourse };
    this.http.put<any>(this.URL + this.id, updatedatas).subscribe({
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
  public delete(id: any) {


    this.http.delete<any>(this.URL + id).subscribe({
      next: data => {
        this.status = "delete successfull";
        console.log("data is successfully deleted");
        this.studentdetails = this.http.get(this.URL);
      },
      error: error => {
        this.errormessage = error.message;
        console.log("There was an error in deleteing the data for given context");
      }
    });
  }
  public select(details: any) {
    this.updatename = details.name;
    this.updatecourse = details.course;
    this.id = details.id;
  }
}


