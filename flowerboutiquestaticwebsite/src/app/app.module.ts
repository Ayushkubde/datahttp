import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Appcomponet2Component } from './appcomponet2/appcomponet2.component';
import { Appcomponent3Component } from './appcomponent3/appcomponent3.component';
import { Appcomponent4Component } from './appcomponent4/appcomponent4.component';

const routes: Routes = [
  { path: 'home', component: Appcomponet2Component },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
]
@NgModule({
  declarations: [
    AppComponent,
    Appcomponet2Component,
    Appcomponent3Component,
    Appcomponent4Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
