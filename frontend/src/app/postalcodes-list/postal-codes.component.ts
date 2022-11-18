import {Component, ViewChild} from '@angular/core';
import PostalCode from "./postalcode/postalcode.component";
import {MatTable, MatTableDataSource} from "@angular/material/table";
import {SendPostalCodeService} from "./services/post-postalcode.service";
import {GetPostalCodesService} from "./services/get-postalcodes.service";

@Component({
  selector: 'app-postalcodes-list',
  templateUrl: './postal-codes.component.html',
  styleUrls: ['./postal-codes.component.css']
})
export class PostalCodesComponent {
  @ViewChild('table') table: MatTable<any>;
  displayedColumns: string[] = ['postalCode', 'distanceInKM', 'distanceInMiles'];
  dataSource: MatTableDataSource<PostalCode>;

  constructor(private postService: SendPostalCodeService,
              private getService: GetPostalCodesService) {
    this.getLastThreePostalCodes();
  }

  public async getLastThreePostalCodes() {
    const data = await this.getService.Execute();
    this.dataSource = new MatTableDataSource(data);
  }

  public async searchPostalCode(event: any) {
    var response = await this.postService.Execute(event);
    return response.data;
  }
}
