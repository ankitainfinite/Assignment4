using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentGenerator.Models;

namespace DocumentGenerator
{
    public class ExcelHandler
    {

        public static void CreateSpreadsheetWorkbook(string filepath, List<Student> students)
        {
           
            SpreadsheetDocument ssDoc = SpreadsheetDocument.Create(filepath,SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookPart = ssDoc.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            Sheets sheets = ssDoc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            //Begin: Sheet 1 Code
            WorksheetPart worksheetPart1 = workbookPart.AddNewPart<WorksheetPart>();
            Worksheet workSheet1 = new Worksheet();
            SheetData sheetData1 = new SheetData();

            // data for sheet 1
            Row rowInSheet1 = new Row();
            rowInSheet1.RowIndex = 2;
            Cell cell = new Cell
            {
                DataType = CellValues.String,
                CellValue = new CellValue("Hello, My name is Ankita")
            };
            rowInSheet1.Append(cell);
            sheetData1.Append(rowInSheet1);

            workSheet1.AppendChild(sheetData1);
            worksheetPart1.Worksheet = workSheet1;

            Sheet sheet1 = new Sheet()
            {
                Id = ssDoc.WorkbookPart.GetIdOfPart(worksheetPart1),
                SheetId = 1,
                Name = "Sheet1"
            };
            sheets.Append(sheet1);
            // End: Sheet 1 Code

            // Begin: Code block for Excel sheet 2
            WorksheetPart worksheetPart2 = workbookPart.AddNewPart<WorksheetPart>();
            Worksheet workSheet2 = new Worksheet();
            SheetData sheetData2 = new SheetData();

            // the data for sheet 2
            Row headerRow = new Row();
            string[] headers = { "UniqueId", "StudentId", "FirstName", "LastName", "DateOfBirth", "isMe", "Age" };
            foreach(var header in headers)
            {
                Cell c = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(header),
                };
                headerRow.Append(c);
            }
            sheetData2.Append(headerRow);
            UInt32 startIndex = 2;
            foreach(Student s in students)
            {
                Row r = new Row();
                r.RowIndex = startIndex;
                Cell uidCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(""+Guid.NewGuid())
                };
                r.Append(uidCell);
                Cell studentIdCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(s.StudentId)
                };
                r.Append(studentIdCell);
                Cell firstNameCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(s.FirstName)
                };
                r.Append(firstNameCell);
                Cell lastNameCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(s.LastName)
                };
                r.Append(lastNameCell);
                Cell dobCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(s.DateOfBirth)
                };
                r.Append(dobCell);
                Cell isMeCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue("" + s.MyRecord)
                };
                r.Append(isMeCell);
                Cell AgeCell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(""+s.Age)
                };
                r.Append(AgeCell);
                sheetData2.Append(r);
                startIndex++;
            }

            workSheet2.AppendChild(sheetData2);
            worksheetPart2.Worksheet = workSheet2;

            Sheet sheet2 = new Sheet()
            {
                Id = ssDoc.WorkbookPart.GetIdOfPart(worksheetPart2),
                SheetId = 2,
                Name = "Sheet2"
            };
            sheets.Append(sheet2);
            // End: Code block for Excel sheet 2
            workbookPart.Workbook.Save();
            ssDoc.Close();
        }

       
    }


}
