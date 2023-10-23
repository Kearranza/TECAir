import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { AppComponent } from './app.component';
import { AdminSelectorComponent } from './admin-selector/admin-selector.component';
import { ClientViewComponent } from './client-view/client-view.component';
import { PromotionsComponent } from './promotions/promotions.component';
import { CheckInComponent } from './check-in/check-in.component';
import { BaggageAssignmentComponent } from './baggage-assignment/baggage-assignment.component';
import { FlightsManagmentComponent } from './flights-managment/flights-managment.component';
import { FlightOpeningComponent } from './flight-opening/flight-opening.component';
import { FlightClosureComponent } from './flight-closure/flight-closure.component';
import { FlightsComponent } from './flights/flights.component';
import { PromotionsManagmentComponent } from './promotions-managment/promotions-managment.component';
import { CreateFlightComponent } from './create-flight/create-flight.component';
import { DeleteFlightComponent } from './delete-flight/delete-flight.component';
import { CreatePromotionComponent } from './create-promotion/create-promotion.component';
import { DeletePromotionComponent } from './delete-promotion/delete-promotion.component';
import { ClientLoginComponent } from './client-login/client-login.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { ReservationComponent } from './reservation/reservation.component';
import { CreateCalendarComponent } from './create-calendar/create-calendar.component';
import { DeleteCalendarComponent } from './delete-calendar/delete-calendar.component';
import { PaymentComponent } from './payment/payment.component';
import { SeatsSelectionComponent } from './seats-selection/seats-selection.component';
import { ThanksComponent } from './thanks/thanks.component';


const routes: Routes = [
  
  {path :'login', component : LoginComponent },

  {path :'app', component : AppComponent},

  {path :'admin-selector', component : AdminSelectorComponent},

  {path :'client-view', component : ClientViewComponent},
  {path :'', component : ClientViewComponent, pathMatch: 'full' },

  {path :'promotions-managment', component : PromotionsManagmentComponent},

  {path :'promotions', component : PromotionsComponent},

  {path :'check-in', component : CheckInComponent},
  
  {path :'baggage-assignment', component : BaggageAssignmentComponent},

  {path :'flights-managment', component : FlightsManagmentComponent},

  {path :'flight-opening', component : FlightOpeningComponent},

  {path :'flight-closure', component : FlightClosureComponent},
  
  {path :'flights', component : FlightsComponent},

  {path :'create-flight', component : CreateFlightComponent},

  {path :'delete-flight', component : DeleteFlightComponent},

  {path :'create-promotion', component : CreatePromotionComponent},

  {path :'delete-promotion', component : DeletePromotionComponent},

  {path :'client-register', component : ClientRegisterComponent},

  {path :'client-login', component : ClientLoginComponent},

  {path :'reservation', component : ReservationComponent},

  {path :'create-calendar', component : CreateCalendarComponent},

  {path :'delete-calendar', component : DeleteCalendarComponent},

  {path :'payment', component : PaymentComponent},

  {path :'seats-selection', component : SeatsSelectionComponent},

  {path :'thanks', component : ThanksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
