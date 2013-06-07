using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Common
{
    public class JSONResult
    {
        public String Result { get; set; }
        public Object Records { get; set; }
        public Object Record { get; set; }
        public String Message { get; set; }
        public Object Options {get;set;}
        public int TotalRecordCount { get; set; }

        public JSONResult()
        {
            Result = "OK";
        }
        public JSONResult(Boolean IsOK,Object records,String message){
            Result = IsOK ? "OK" : "ERROR";
            Records = records;
            Message = message;
        }
        public JSONResult(Object records,String Type = "Records")
        {
            Result = "OK";
           if(Type.Equals("Records")){
               Records = records;
           }else if(Type.Equals("Options")){
               Options = records;
           }else if(Type.Equals("Record")){
               Record = records;
           }
        }
        public JSONResult(String message)
        {
            Result = "ERROR";
            Message = message;
        }
        public JSONResult(Exception e)
        {
            Result = "ERROR";
            Message = "ERROR : " + e.Message;
        }
    }
}