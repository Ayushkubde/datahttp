import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Appcomponet2Component } from './appcomponet2/appcomponet2.component';
import { Appcomponent3Component } from './appcomponent3/appcomponent3.component';
import { Appcomponent4Component } from './appcomponent4/appcomponent4.component';

const routes: Routes = [
   {
      path: 'firstcomponent',
      component: Appcomponet2Component
   },
   {
      path: 'secondcomponent',
      component: Appcomponent3Component
   },
   {
      path:'thirdcomponent',
      component:Appcomponent4Component
   }

];

@NgModule({
   imports: [
      RouterModule.forRoot(routes)
   ],
   exports: [
      RouterModule
   ],
   declarations: []
})
export class AppRoutingModule { }