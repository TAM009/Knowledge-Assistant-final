//Servie to show the Contents fully

import { ContentID } from './ContentID';
import { Content } from './Content';
import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()

export class ViewService {

   //Local variables to capture the incoming objects
   content: ContentID;
   usercontentdetails:string;
   
   
      showrecievedcontent(con: string){
          this.usercontentdetails= con;
          console.log("reached view servie"+this.usercontentdetails);
      }

   constructor(private http: Http) { }

   //Function to capture the incoming object
   show(content: ContentID)
    {
        this.content = content;
    }


}