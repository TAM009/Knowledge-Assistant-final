import { Appconfig } from './app.config';
import { ShareDetails } from './shareddetails';
import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import {Observable} from 'rxjs/Rx';

@Injectable()
export class fetchIDsService {
   public common_ContentID: any;
   public common_FileID:any;
   public common_SharedBy:any;
   public common_CreatedBy: any;
   public headers: Headers;
   public getFileIDUrl: any;
   public getCreateByUrl :any;
   public getSharedWithUrl: any;
   public postInContentShare: any;
   public getallfromcontentshare: any;
   public getallfromUserdetails: any;
   public getallcontentdetailbycontentid: any;
   public searchLetters: any;
   constructor(public http:Http, private config: Appconfig ){

       this.getFileIDUrl = this.config.getfileidurl;
       this.getCreateByUrl = this.config.getcreatedbyurl;
       this.getSharedWithUrl = this.config.getsharedwithurl;
       this.postInContentShare = this.config.postincontentshareurl;
       this.getallfromcontentshare=this.config.getallfromContentshareurl;
       this.getallfromUserdetails=this.config.getallfromuserDetailsurl;
       this.getallcontentdetailbycontentid= this.config.getallcontentdetailbycontentidurl;
       this.searchLetters= this.config.searchlettersurl;
   }
   getallfromContentShare(){
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.getallfromcontentshare),{headers:this.headers})
   }

   getallfromuserdetails(){
       this.headers = new Headers({'Content-Type':'application/json'});
      return this.http.get((this.getallfromUserdetails),{headers:this.headers})
   }
   getextractedsharedfiles(contID: number):Promise<any>{
       console.log('insidefetchids '+contID);
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.getallcontentdetailbycontentid+contID),{headers:this.headers}).toPromise()
   
   }
   getdropdown(searchletters: string){
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.searchLetters+searchletters+''),{headers:this.headers})
   }
   getFileID(trial_User_userID: any,trial_contentID: any){
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.getFileIDUrl+trial_User_userID+'/'+trial_contentID+''),{headers:this.headers})
   }
   getCreatedBy(trial_User_userID: any){
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.getCreateByUrl+trial_User_userID+''),{headers:this.headers})
   }

   getSharedWith(trial_Recipients_name: any){
       this.headers = new Headers({'Content-Type':'application/json'});
       return this.http.get((this.getSharedWithUrl+trial_Recipients_name+''),{headers:this.headers})
   }

   postinContentshare(passterm: ShareDetails){
       this.headers = new Headers({'Content-Type':'application/json'});
       this.http.post(this.postInContentShare,JSON.stringify(passterm),{headers:this.headers}).toPromise().catch();
   }
   
}