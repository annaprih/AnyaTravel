/**
 * Created by annae on 21.04.2018.
 */
import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {ServerResponse} from "../models/ServerResponse";

@Injectable()
export class OrderService {

  private _http;

  constructor(http: Http) {
    this._http = http;
  }

  public async getAllOrders(): Promise<any> {
    return (await this._http.get('/api/order').toPromise()).json();
  }

  public async getOrdersByUser(): Promise<any> {
    return (await this._http.get('/api/order/currentuser').toPromise()).json();
  }

  public async addOrder(tourId: number): Promise<ServerResponse<any>> {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.post(`api/order/${tourId}`).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  public async updateOrder(id: number): Promise<ServerResponse<any>> {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.put(`api/order/${id}`).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  public async deleteOrder(id: number): Promise<ServerResponse<any>> {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.delete(`api/order/${id}`).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  private parseResponse(response): ServerResponse<any> {
    let res: ServerResponse<any> = new ServerResponse<any>();
    res.statusCode = response.status;
    if (response._body) {
      res.data = response.json();
    }
    return res;
  }

}
