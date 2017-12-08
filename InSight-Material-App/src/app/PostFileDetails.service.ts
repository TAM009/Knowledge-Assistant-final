import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { FileUpload } from './File';
import { Content } from './Content';
import { Appconfig } from './app.config';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class FileDetailsUploaderService 
{
     constructor(private http: Http,private appconfig:Appconfig) {}

     //form1: HTMLFormElement;
     //content1:string;
     fileName:string;
     fileType:string;
     filePath:string;
     //filedetails: FilesDetails;
     //contentdetails:ReceiveContentDetails;
     contentId:number;

     //For else condition.
     fileName2: string = null;
     fileType2: string = null;
     filePath2: string = null;

     //private apiUrl2: string ="http://localhost:5000/api/ContentDetails";
     private fileDetailsUploadUrl:string =this.appconfig.gateway_files_editor_url;
     content: Content;
     //receiveContent:ReceiveContentDetails;

     //Attributes to be initialised from local storage
     userId:number;
     id:string;
     createdBy:string;
     baseurl:string;
     userIdString:string;
     contentIdString:string;
     contentIdfilename:number;

     //Object used for posting
     fileUpload:FileUpload;
     fileUpload2:FileUpload;


     PostFileDetails( files: File[], form: HTMLFormElement, contentID:number )
     {
        //Information obtained from local storage.
        this.id = localStorage.getItem('id');
        this.userId = parseInt(this.id);//UserId
        this.createdBy = localStorage.getItem('username');//Username
        this.contentIdfilename=contentID;//ContentId

        //BaseUrl to obtain link of files uploaded in amazon s3
        this.baseurl="https://s3.ap-south-1.amazonaws.com/testinsight95/";

        //Modification made to send unique fileName to AmazonS3 to avoid versioning and overwriting of files
        this.userIdString=this.userId.toString();
        console.log("useridstr is "+this.userIdString);
        this.contentIdString=this.contentIdfilename.toString();
        console.log("contentidstr is "+ this.contentIdString);
        
        

        // this.content= new ContentDetails(content);
        // let headers=new Headers({'Content-type':'application/json'});
        // let options=new RequestOptions({headers:headers});

        // this.http.post(this.apiUrl2,JSON.stringify(this.content),options).subscribe((success)=>{console.log(success!!)},
        // (res:Response)=>{this.receiveContent=res.json() as ReceiveContentDetails});

        // this.contentID=this.receiveContent.contentID;


        //this.form1=form;
        //this.content1=content;
        // let body = {
        //     "contentID": 2,
        //     "filename"
        // };


        // let headers = new Headers();    
        // headers.append('Content-Type', 'application/json');  
        // let options = new RequestOptions({ headers: headers });
        // //this.http.post("http://localhost:5000/api/ContentDetails",JSON.stringify(content),options).subscribe((res:Response)=>this.contentdetails=res.json() as ContentDetails);

        // this.http.post("http://localhost:5000/api/ContentDetails",body,options).subscribe((res:Response)=>{this.contentdetails=res.json() as ReceiveContentDetails},
        // (success)=>console.log("Success!!"));
        
        // this.contentID=this.contentdetails.contentID;
        
        let fileList: File[]=files;

        if (fileList.length > 0) 
        {      
            for( let i=0; i <fileList.length; i++)
            {  
                let file: File = fileList[i];  
                console.log(file);
                console.log(file.name);
                console.log(file.type);

                //Initialising local variables with the parameters obtained from function to be passed as initalizers of the FileDetails constructor in order to avoid "Undefined" error.
                this.fileName=this.userIdString+'_'+ this.contentIdString+'_'+file.name;//Get the filename of the current file
		//this.fileName=file.name;
                this.fileType=file.type;
                this.filePath=this.baseurl+this.fileName;
		console.log(this.fileName);
		console.log(this.filePath);
		console.log("ContentId in postfiledetails"+this.contentIdfilename)

                //Pass the details within body as JSON to map the data with he database model and post correctly.
                // let body = {
                //     "contentID":contentID,
                //     "filename":this.fileName,
                //     "filetype":this.fileType
                // };

                //console.log("Body of transferred file is "+body);

                this.fileUpload=new FileUpload(this.userId,this.contentIdfilename,this.filePath,this.fileName,this.fileType,this.createdBy)

                //Http Post Code to FileTable
                let headers = new Headers();    
                headers.append('Content-Type', 'application/json');  
                let options = new RequestOptions({ headers: headers });  
                
                //let apiUrl1 = "http://localhost:5000/api/FilesDetails"; 
                //console.log(apiUrl1,body);
                this.http.post(this.fileDetailsUploadUrl,JSON.stringify(this.fileUpload), options)
                .subscribe(  
                data => console.log(data),  
                error => console.log(error)
                )
            }
        }

        else
        {
            this.fileUpload2=new FileUpload(this.userId,this.contentIdfilename,this.filePath2,this.fileName2,this.fileType2,this.createdBy)
            
            //Http Post Code to FileTable
            let headers = new Headers();    
            headers.append('Content-Type', 'application/json');  
            let options = new RequestOptions({ headers: headers });  
            
            //let apiUrl1 = "http://localhost:5000/api/FilesDetails"; 
            //console.log(apiUrl1,body);
            this.http.post(this.fileDetailsUploadUrl,JSON.stringify(this.fileUpload2), options)
            .subscribe(  
            data => console.log(data),  
            error => console.log(error)
            )
        }
    }

}
