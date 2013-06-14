using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.Mvc;
namespace DropIt.Common
{
    
    public class FilePath
    {
        private String Path;
        private String File;
        public FilePath(String Path, String File)
        {
            this.Path = Path;
            this.File = File;
        }

        public override string ToString()
        {
            return Path + File;
        }

    }
    public static class Uploader
    {
        public static string UploadPath = "~/Content/Upload/";

        public static FilePath Upload(HttpPostedFileBase file,Controller controller)
        {
            string pic = System.IO.Path.GetFileName(file.FileName);
            string path = System.IO.Path.Combine(controller.Server.MapPath(UploadPath), pic);
            // file is uploaded
            file.SaveAs(path);

            FilePath filePath = new FilePath(UploadPath, pic);
            return filePath;
        }

    }
}