import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';

import {Routes, RouterModule} from '@angular/router';

import {HttpModule} from '@angular/http';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {DataTablesModule} from 'angular-datatables';
import {EditableModule} from 'ng2-editable';
import { MomentModule } from 'angular2-moment';

import {HttpAuthService} from "./services/auth.service";
import {TourService} from "./services/tour.service";
import {Auth0Service} from "./auth/auth0.service";
import {UserService} from "./services/user.service";
import {OrderService} from "./services/order.service";



import {AppComponent} from './components/app/app.component';
import {LoginComponent} from './components/login/login.component';
import {SignUpComponent} from './components/signUp/signUp.component';
import {HomeComponent} from "./components/home/home.component";
import {UserPageComponent} from "./components/userpage/userpage.component";
import {AdminPageComponent} from './components/adminpage/adminpage.component';
import {TourViewComponent} from './components/tourview/tourview.component';
import {CreateTourComponent} from './components/createtour.component/createtour.component';



const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'signUp', component: SignUpComponent},
  {path: 'user', component: UserPageComponent},
  {path: 'admin', component: AdminPageComponent},
  {path: 'tourView/:tourId', component: TourViewComponent},
  {path: 'createTour', component: CreateTourComponent},
  {path: '**', component: HomeComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    HomeComponent,
    UserPageComponent,
    AdminPageComponent,
    TourViewComponent,
    CreateTourComponent
  ],
  imports: [
    BrowserModule,
    MomentModule,
    HttpClientModule,
    HttpModule,
    DataTablesModule,
    EditableModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    HttpAuthService,
    Auth0Service,
    TourService,
    UserService,
    OrderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
