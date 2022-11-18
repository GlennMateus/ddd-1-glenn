import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {PostalCodesComponent} from "../postalcodes-list/postal-codes.component";
import PostalCode from "../postalcodes-list/postalcode/postalcode.component";

@Component({
  selector: 'app-searchbar',
  templateUrl: './searchbar.component.html',
  styleUrls: ['./searchbar.component.css']
})
export class SearchbarComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  postalCode: PostalCode;

  constructor(private fb: FormBuilder, private postalCodes: PostalCodesComponent) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      search: [null, [Validators.required, Validators.minLength(5)]]
    });
  }

  async onSubmit(form: any) {
    var response = await this.postalCodes.searchPostalCode(form.value.search);
    form.reset();
    this.postalCode = response;
  }

  reloadPage() {
    window.location.reload();
  }
}
