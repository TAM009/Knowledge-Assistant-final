import { UserContentDetails } from './../receivedfiles/UserContentDetails';
import { ViewService } from './../view.service';
import { Component, OnInit } from '@angular/core';


@Component({
 selector: 'app-viewrecievedfiles',
 templateUrl: './viewrecievedfiles.component.html',
 styleUrls: ['./viewrecievedfiles.component.css']
})
export class ViewrecievedfilesComponent implements OnInit {

 public usercontdetails: string;
 public content: string;
 constructor(public objviewservice: ViewService) {
   this.usercontdetails = this.objviewservice.usercontentdetails;
   this.content = this.usercontdetails;
   console.log("from the view component"+this.usercontdetails);
  }

 ngOnInit() {
 }

}