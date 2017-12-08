using ApiGateway.Controllers;

namespace  Configuration
{
    public class AppConfig
    {  
        public string serverurl= "http://localhost:5004/";
        public string tokenserverurl="http://localhost:5003/";
        public string facebookurl="http://localhost:5001/";
        public string googleurl="http://localhost:5002/";
        // public string contentDetailsUrl="http://172.23.238.139:5050/";
        // public string filesDetailsUrl="http://172.23.238.139:5050/";
        // public string contentDetailsUrl="http://172.23.238.139:5005/";
        // public string filesDetailsUrl="http://172.23.238.139:5005/";
        // public string amazonUploadUrl="http://172.23.238.139:5005/";

        public string contentDetailsUrl="http://localhost:5005/";
        public string filesDetailsUrl="http://localhost:5005/";
        //public string amazonUploadUrl="http://localhost:5005/";
    
        //public string googleurl="http://172.23.238.147:8555/";
        
        
   }
}

