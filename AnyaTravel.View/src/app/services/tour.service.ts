/**
 * Created by annae on 20.04.2018.
 */
import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {ServerResponse} from "../models/ServerResponse";


@Injectable()
export class TourService {

  private _http;

  constructor(http: Http) {
    this._http = http;
  }

  public async getAllTours(): Promise<any> {
    return (await this._http.get('/api/tour').toPromise()).json();
  }

  public async getAllDataForTour(): Promise<any> {
    return (await this._http.get('/api/getalldatafortour').toPromise()).json();
  }


  public async getTourById(id: number): Promise<ServerResponse<any>> {
    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.get(`/api/tour/${id}`).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  public async addTour(tour: any): Promise<ServerResponse<any>>  {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.post(`api/tour`, tour).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  public async updateTour(tour: any): Promise<ServerResponse<any>>  {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.put(`api/tour`, tour).toPromise());
      result = this.parseResponse(response);
    } catch (ex) {
      result = this.parseResponse(ex);
    }
    return result;
  }

  public async deleteTour(id: number): Promise<ServerResponse<any>> {

    let result: ServerResponse<any> = new ServerResponse<any>();
    try {
      let response = (await this._http.delete(`api/tour/${id}`).toPromise());
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
