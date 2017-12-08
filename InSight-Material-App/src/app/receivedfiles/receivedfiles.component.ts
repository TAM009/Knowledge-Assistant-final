import { fetchIDsService } from './../fetchIDs.service';
import { UserDetails } from './../pre-result/UserDetails';
import { ViewService } from './../view.service';
import { ContentID } from './../ContentID';
import { UserContentDetails } from './UserContentDetails';
import { ContentShared } from './ContentShared';
import { Component, Inject, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { HttpModule } from '@angular/http';
@Component({
  selector: 'app-receivedfiles',
  templateUrl: './receivedfiles.component.html',
  styleUrls: ['./receivedfiles.component.css']
})
export class ReceivedfilesComponent implements OnInit {
  p: number = 1;
  headers = new Headers;
  public extractedsharedfiles : any;
  public extractedsharedfiles2 : any;
  public extractedsharedfiles3 : any;
  public extractedcontentstobedisplayed: any;
  public User_userID_hardcoded: number = 13;
  public array: UserContentDetails[]=[];
  public arraysharedon: Date[]=[];
  public nooffilestobeshared: number;
  public sharedondate: any;
  public contID: number;
  public getalluserdetails : any;
  public resultstore: any;
  public con: string;
  public filtereduser:any;
  public current_usersID : number;
  public sample: string;
  public limit: number = 500;
  public dots: string = "....";
  constructor(public http:Http,public fetchidserv: fetchIDsService, public viewser:ViewService) {
                
    this.fetchidserv.getallfromuserdetails() //gets all the data from userdetails table
    .subscribe(result => {
      this.getalluserdetails = result.json() as UserDetails,console.log('inside constructor'), console.log(this.getalluserdetails);
    });
    this.extract_shared_files(); //calls the fuction in constructor itself
   }
   //this function gives the user who shared the file with the current user.
   getsharedbyusername(sharedbyid: number){
          
        this.filtereduser =  this.getalluserdetails.filter(item => item.userID == sharedbyid) as UserDetails[];
        return this.filtereduser[0]['firstName'];
       }
       //this function is to limit the number of letters displayed in the recieved files page in the cards.
   addDots(/*con: UserContentDetails*/ str: string, contentID: number) {
    this.sample = str;
    this.contID = contentID;
 
    if (this.sample.length > this.limit) {
      this.sample = this.sample.substring(0, this.limit) + this.dots;
    }
    return this.sample;
  }
  //this function first gets the current users UserID from localstorage and then retrives the whole data 
  // from Contentshare table and then filters out only the files that are shared with the current user.
   extract_shared_files(){
    var Current_usersID = localStorage.getItem('id');
    console.log("sagfashfdghasf "+Current_usersID);
    this.current_usersID = Number(Current_usersID);
    console.log('current users id is '+ this.current_usersID);
  
    
    this.fetchidserv.getallfromContentShare()
    .toPromise()
    .then(result =>{
        this.extractedsharedfiles = result.json().filter(item => item.sharedWith == this.current_usersID) as ContentShared[] , console.log(this.extractedsharedfiles);
        this.nooffilestobeshared =this.extractedsharedfiles.length;
        console.log('no. of files to be shared is '+ this.nooffilestobeshared);
      console.log(this.extractedsharedfiles[0]['createdOn']);
        
        this.testLoop();
      })
  }
  //this function uses the contentID from  ContentShareTable and goes into the ContentDetailstable and 
  //fetches corresponding row json that matches with the contentID in the ContentDetails table.
  testLoop(){
    var i = 0;
     
     
    do {
       console.log("next contentID "+this.extractedsharedfiles[i]['contentID']);
       this.sharedondate = this.extractedsharedfiles[i]['createdOn'];
       this.arraysharedon.push(this.sharedondate);
       this.fetchidserv.getextractedsharedfiles(this.extractedsharedfiles[i]['contentID'])
        
       
       .then(result=>
        {
          this.extractedcontentstobedisplayed = result.json() as UserContentDetails[],
          console.log(this.extractedcontentstobedisplayed);
         this.array.push(this.extractedcontentstobedisplayed );
          console.log(this.array);
        });
        
       i++;
    }
    while (i < this.nooffilestobeshared);
    
    console.log('yoyo'+i);
    console.log(this.array);
  }
  view(str :string)
  {
    // this.con = con;
    console.log("view function"+ str);
    this.viewser.showrecievedcontent(str);
  }
  ngOnInit() {
  }
}
