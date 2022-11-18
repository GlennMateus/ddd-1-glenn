import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {SearchbarComponent} from './searchbar/searchbar.component';
import {RouterModule} from "@angular/router";
import {PostalCodesComponent} from './postalcodes-list/postal-codes.component';
import {HttpClientModule} from "@angular/common/http";
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MaterialModule} from "./material.module";
import {ReactiveFormsModule} from "@angular/forms";
import {GetPostalCodesService} from "./postalcodes-list/services/get-postalcodes.service";
import {SendPostalCodeService} from "./postalcodes-list/services/post-postalcode.service";

@NgModule({
  declarations: [
    AppComponent,
    SearchbarComponent,
    PostalCodesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    RouterModule.forRoot([
      {path: '', component: SearchbarComponent, pathMatch: 'full'}
    ]),
    NoopAnimationsModule
  ],
  providers: [
    PostalCodesComponent,
    GetPostalCodesService,
    SendPostalCodeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
