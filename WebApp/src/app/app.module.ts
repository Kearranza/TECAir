import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AdminSelectorComponent } from './admin-selector/admin-selector.component';
import { ClientViewComponent } from './client-view/client-view.component';
import { PromotionsComponent } from './promotions/promotions.component';
import { CheckInComponent } from './check-in/check-in.component';
import { BaggageAssignmentComponent } from './baggage-assignment/baggage-assignment.component';
import { FlightsManagmentComponent } from './flights-managment/flights-managment.component';
import { FlightOpeningComponent } from './flight-opening/flight-opening.component';
import { FlightClosureComponent } from './flight-closure/flight-closure.component';
import { FooterComponent } from './footer/footer.component';
import { PromotionsManagmentComponent } from './promotions-managment/promotions-managment.component';
import { FlightsComponent } from './flights/flights.component';
import { CreateFlightComponent } from './create-flight/create-flight.component';
import { CreatePromotionComponent } from './create-promotion/create-promotion.component';
import { DeletePromotionComponent } from './delete-promotion/delete-promotion.component';
import { DeleteFlightComponent } from './delete-flight/delete-flight.component';
import { FlightDisplayComponent } from './flight-display/flight-display.component';
import { PromotionDisplayComponent } from './promotion-display/promotion-display.component';
import { ClientLoginComponent } from './client-login/client-login.component';
import { ClientRegisterComponent } from './client-register/client-register.component';
import { ReservationComponent } from './reservation/reservation.component';
import { CreateCalendarComponent } from './create-calendar/create-calendar.component';
import { DeleteCalendarComponent } from './delete-calendar/delete-calendar.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    AdminSelectorComponent,
    ClientViewComponent,
    PromotionsComponent,
    CheckInComponent,
    BaggageAssignmentComponent,
    FlightsManagmentComponent,
    FlightOpeningComponent,
    FlightClosureComponent,
    FooterComponent,
    PromotionsManagmentComponent,
    FlightsComponent,
    CreateFlightComponent,
    CreatePromotionComponent,
    DeletePromotionComponent,
    DeleteFlightComponent,
    FlightDisplayComponent,
    PromotionDisplayComponent,
    ClientLoginComponent,
    ClientRegisterComponent,
    ReservationComponent,
    CreateCalendarComponent,
    DeleteCalendarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
