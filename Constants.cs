using System;
namespace DocumentGenerator
{
    public class Constants
    {
        public class FTP
        {
            public const string BaseUrl = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-20914/";
            public const string ExcelDest = BaseUrl + "200425898 Ankita Singh/info.xlsx";
            public const string DocDest = BaseUrl + "200425898 Ankita Singh/info.docx";
            public const string ImageUrl = BaseUrl + "200425898 Ankita Singh/myimage.jpg";
            public const string username = @"bdat100119f\bdat1001";
            public const string password = "bdat1001";
        }

        public class LOCAL
        {
            public const string BaseUrl = "/Users/ankitasingh/Projects/DocumentGenerator/DocumentGenerator/";
            public const string JsonPath = BaseUrl + "Contents/Data/students.json";
            public const string ExcelPath = BaseUrl + "Uploads/info.xlsx";
            public const string DocPath = BaseUrl + "Uploads/info.docx";
            public const string ImageDest = BaseUrl + "Contents/Images/myimage.jpg";
        }
         
    }
}
