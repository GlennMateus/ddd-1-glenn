import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import api from "../../services/api";

@Injectable()
export class SendPostalCodeService {
  public async Execute(postalCode: String) {
    return await api.post(`/api/postalcodes/${postalCode}`);
  }
}
