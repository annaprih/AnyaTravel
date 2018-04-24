import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {TourService} from '../../services/tour.service'
import {ServerResponse} from "../../models/ServerResponse";

@Component({
  templateUrl: './createtour.component.html',
  styleUrls: ['./createtour.component.css']
})

export class CreateTourComponent implements OnInit{

  public tourInformation: any;
  public errors: Array<string> = new Array<string>();
  public tour: any;

  constructor(private tourService: TourService,
              private router: Router,
              private activateRoute: ActivatedRoute) {
  }

  async ngOnInit() {
    this.tourInformation = await this.tourService.getAllDataForTour();
  }

  load = false;

  async create() {
    this.load = true;
    let response: ServerResponse<any> = await this.tourService.addTour(this.tour);
    if (response.statusCode == 200) {
      this.load = false;
      this.router.navigate([`tourView/${response.data.id}`]);
    } else if (response.statusCode == 400) {
      for (let key in response.data) {
        response.data[key].forEach((item) => {
          this.errors.push(`${key}: ${item}`);
        })
      }
    } else {
      console.log(response);
    }
    this.load = false;
  }
}
