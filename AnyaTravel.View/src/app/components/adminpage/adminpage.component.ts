import {Component, OnInit, ViewChild} from '@angular/core';
import {Router} from '@angular/router';
import {DataTableDirective} from 'angular-datatables';

import {OrderService} from '../../services/order.service'
import {HttpAuthService} from '../../services/auth.service'
import {ServerResponse} from "../../models/ServerResponse";
import {Subject} from 'rxjs/Subject';


@Component({
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.css']
})

export class AdminPageComponent implements OnInit {

  @ViewChild(DataTableDirective) dtElement: DataTableDirective;

  public orders = [];
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject();

  constructor(private httpAuthService: HttpAuthService,
              private orderService: OrderService,
              private router: Router) {
     this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      paging: true
    };

    this.dtTrigger.next();
  }

  load = false;

  async ngOnInit() {
    this.orders = await this.orderService.getAllOrders();
    this.dtTrigger.next();
  }

  async deleteOrder(id) {
    this.load = true;
    let response: ServerResponse<any> = await this.orderService.deleteOrder(id);
    if (response.statusCode == 200) {
      this.dtElement.dtInstance.then(async (dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.orders = await this.orderService.getAllOrders();
        this.load = false;
        this.dtTrigger.next();
      });
    } else {
      console.log(response);
    }
  }

  async updateOrder(tourId) {
    this.load = true;
    let response: ServerResponse<any> = await this.orderService.updateOrder(tourId);
    if (response.statusCode == 200) {
      this.dtElement.dtInstance.then(async (dtInstance: DataTables.Api) => {
        dtInstance.destroy();
        this.orders = await this.orderService.getAllOrders();
        this.load = false;
        this.dtTrigger.next();
      });
    } else {
      console.log(response);
    }
  }

}
