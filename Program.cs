using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocumentGenerator.Models;
using Newtonsoft.Json;

namespace DocumentGenerator
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Fetching Data from API");
            var data = DataHandler.getData();
            var models = JsonConvert.DeserializeObject<List<User.RootObject>>(data);
            List<User.RootObject> users = models.ToList();
            Console.WriteLine("Fetching Data Completed");
            Console.WriteLine("Fetching Image from FTP Server");
            FTP.DownloadFile(Constants.FTP.ImageUrl, Constants.LOCAL.ImageDest);
            Console.WriteLine("Fetching Image Completed");
            Console.WriteLine("Generating the Document");
            DocHandler.CreateWordprocessingDocument(Constants.LOCAL.DocPath, users);
            Console.WriteLine("Document Generated");
            Console.WriteLine("Uploading info.docx");
            FTP.UploadFile(Constants.LOCAL.DocPath, Constants.FTP.DocDest);
            Console.WriteLine("Uploading Completed");


            //Question 2
            List<Student> students;
            using (StreamReader r = new StreamReader(Constants.LOCAL.JsonPath))
            {
                string json = r.ReadToEnd();
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            Console.WriteLine("Generating Excel File");
            ExcelHandler.CreateSpreadsheetWorkbook(Constants.LOCAL.ExcelPath, students);
            Console.WriteLine("Excel File Generated");
            Console.WriteLine("Uploading the Excel file");
            FTP.UploadFile(Constants.LOCAL.ExcelPath, Constants.FTP.ExcelDest);
            Console.WriteLine("Uploading Completed");
        }
    }



}
