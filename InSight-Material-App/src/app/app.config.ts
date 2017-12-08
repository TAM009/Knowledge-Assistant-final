export class Appconfig{

    
    /* public readonly editor_url ="http://localhost:5050/api/ContentDetails";  */
    // public readonly editor_url = "http://localhost:5000/api/UserContentDetails"; 
    //public readonly editor_url = "http://172.23.238.147:5005/api/ContentDetails";
    //public readonly editor_url  = "http://172.23.238.139:5050";
    // public readonly editor_url = "http://172.23.238.142:5000/api/UserContentDetails"; 
    // public readonly editor_url  = "http://localhost:5000/api/ContentDetails"; 
    
    public readonly apifav_url_update = 'http://localhost:7777/api/favourites';
    public readonly searchurl="http://insight.blr.stackroute.in:5008/api/postsearch";
    public readonly fileuploadurl="http://localhost:5008/api/FileSystemUpload";

    public readonly apiUrl = 'http://insight.blr.stackroute.in:5000/api/authentication';
    public readonly apiUrl_register = 'http://insight.blr.stackroute.in:5000/api/register';
    public readonly apiUrl_socialfacebook='http://insight.blr.stackroute.in:5000/api/facebook';
    /* public readonly apiUrl_socialgoogle='http://localhost:8087/api/google'; */
    public readonly apiUrl_socialgoogle =  "http://insight.blr.stackroute.in:5000/api/google";

    public readonly getfileidurl = 'http://insight.blr.stackroute.in:4200/api/UserFileDetails/';
    public readonly getcreatedbyurl = 'http://insight.blr.stackroute.in:4200/api/UserDetails/getbyuserid/';
    public readonly getsharedwithurl = 'http://insight.blr.stackroute.in:4200/api/UserDetails/getbyfirstname/';
    public readonly postincontentshareurl = 'http://insight.blr.stackroute.in:4200/api/ContentShare';
    public readonly getallfromContentshareurl= 'http://insight.blr.stackroute.in:4200/api/ContentShare';
    public readonly getallfromuserDetailsurl= 'http://insight.blr.stackroute.in:4200/api/UserDetails';
    public readonly getallcontentdetailbycontentidurl = 'http://insight.blr.stackroute.in:4200/api/UserContentDetails/getallbycontentID/';
    public readonly searchlettersurl = 'http://insight.blr.stackroute.in:4200/api/UserDetails/GetClientList/term?term=';

    //public readonly apiUrl = 'http://localhost:8080/api/authentication';
    //public readonly apiUrl_register = 'http://localhost:8080/api/register';
    //public readonly apiUrl_socialfacebook='http://localhost:8080/api/facebook';
    //public readonly apiUrl_socialgoogle='http://localhost:8080/api/google';
    //public readonly amazonUploadUrl="http://localhost:5050/api/AmazonS3Upload";
    //public readonly filesDetailsUrl="http://localhost:5050/api/FilesDetails";
    //public readonly apiUrl_settings ='http://172.23.238.219:5467/api/settings/';
    //public readonly apiUrl_amazon= 'http://172.23.238.219:5467/api/amazons3upload' ;
    //public readonly apiUrl_settingsPhoto= "http://172.23.238.219:5467/api/SettingsPhoto/";
    //public readonly apiUrl_settingscontact ='http://172.23.238.219:5467/api/settingscontact/';  
    //public readonly apiUrl_settingsdob ='http://172.23.238.219:5467/api/settingsdob/'; 
    public readonly apiUrl_email='http://insight.blr.stackroute.in:5000/api/email';
    public readonly apiUrl_password='http://insight.blr.stackroute.in:5004/api/changepassword/';
    // public readonly apiUrl = 'http://localhost:8087/api/authentication';
    // public readonly apiUrl_register = 'http://localhost:8087/api/register';
    // public readonly apiUrl_socialfacebook='http://localhost:8087/api/facebook';
    // public readonly apiUrl_socialgoogle='http://localhost:8087/api/google';

   // public readonly amazonUploadUrl="http://localhost:5050/api/AmazonS3Upload";
    //public readonly filesDetailsUrl="http://localhost:5050/api/FilesDetails";
    // public readonly apiUrl_settings ='http://localhost:5467/api/settings/';
    // public readonly apiUrl_amazon= 'http://localhost:5467/api/amazons3upload' ;
    // public readonly apiUrl_settingsPhoto= "http://localhost:5467/api/SettingsPhoto/";
    // public readonly apiUrl_settingscontact ='http://localhost:5467/api/settingscontact/';  
    // public readonly apiUrl_settingsdob ='http://localhost:5467/api/settingsdob/'; 

    //public readonly apiUrl_email='http://localhost:8087/api/email';
    //public readonly apiUrl_password='http://localhost:1234/api/changepassword/';  
    //public readonly editor_url="http://172.23.238.139:5050/api/ContentDetails";
    // public readonly editor_url ="http://172.23.238.139:5050/api/ContentDetails";
    // public readonly filesDetailsUrl="http://172.23.238.147:5050/api/FilesDetails";
    // public readonly amazonUploadUrl="http://172.23.238.139:5050/api/AmazonS3Upload";
    // public readonly editor_url="http://172.23.238.147:5050/api/ContentDetails";

    public readonly editor_url = "http://insight.blr.stackroute.in:3000/api/ContentDetails";
    /* public readonly filesDetailsUrl="http://172.23.238.139:5050/api/FilesDetails"; */
    public readonly filesDetailsUrl = "http://insight.blr.stackroute.in:3000/api/FilesDetails";
    public readonly amazonUploadUrl="http://insight.blr.stackroute.in:3000/api/AmazonS3Upload";

   
    public readonly apiUrl_settings ='http://insight.blr.stackroute.in:8090/api/settings/';
    public readonly apiUrl_amazon= 'http://insight.blr.stackroute.in:8090/api/amazons3upload' ;
    public readonly apiUrl_settingsPhoto= "http://insight.blr.stackroute.in:8090/api/SettingsPhoto/";
    public readonly apiUrl_settingscontact ='http://insight.blr.stackroute.in:8090/api/settingscontact/';  
    public readonly apiUrl_settingsdob ='http://insight.blr.stackroute.in:8090/api/settingsdob/';

   public readonly gateway_editor_url ="http://insight.blr.stackroute.in:5000/api/ContentDetails";
   public readonly gateway_files_editor_url ="http://insight.blr.stackroute.in:5000/api/FilesDetails";
   public readonly gateway_amazon_editor_url="http://insight.blr.stackroute.in:5000/api/AmazonS3Upload";
}
