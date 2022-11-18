import {Injectable} from "@angular/core";
import PostalCode from "../postalcode/postalcode.component";
import {HttpClient} from "@angular/common/http";
import api from "../../services/api";

@Injectable()
export class GetPostalCodesService {
  private http: HttpClient;
  private baseURL: string = '';
  private postalCodes: PostalCode[] = [];

  public async Execute() {
    const response = await api.get(`/api/postalcodes`);
    const data = await response.data;
    return data;
  }
}
