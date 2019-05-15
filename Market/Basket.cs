using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Market
{
    class Basket
    {
        public List<Product> product = new List<Product>();


        public const string fileNameTxt = "product.txt";
        public const string fileNameJson = "productjson.json";
        public const string fileNameExcel = "productExcel.xlsx";

        public void fillWithDummyData()
        {

            product.Add(new Product(1, "Ball", 20, 1));
            product.Add(new Product(2, "T-shirt", 30, 2));
            product.Add(new Product(3, "Energy Drink", 3, 3));
        }

        public bool SaveToFile()
        {

            try
            {
                using (StreamWriter file = new StreamWriter(fileNameTxt))
                {
                    foreach (Product t in product)
                    {
                        file.WriteLine(t);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public bool SaveToJson()
        {
            try
            {
                string json = JsonConvert.SerializeObject(product.ToArray());
                //write string to file
                File.WriteAllText(fileNameJson, json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool SaveToExcel()
        {
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Mysheet");

            var r = sheet.CreateRow(0);

            r.CreateCell(0).SetCellValue("ID");
            r.CreateCell(1).SetCellValue("Name");
            r.CreateCell(2).SetCellValue("Price");
            r.CreateCell(3).SetCellValue("Category");

            for (int i = 0; i < product.Count; i++)
            {

                r = sheet.CreateRow(i + 1);

                r.CreateCell(0).SetCellValue(product[i].id);
                r.CreateCell(1).SetCellValue(product[i].name);
                r.CreateCell(2).SetCellValue(product[i].price);
                r.CreateCell(3).SetCellValue(product[i].category);




            }
            try
            {
                using (var fs = new FileStream(fileNameExcel, FileMode.Create, FileAccess.Write))
                {
                    wb.Write(fs);

                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }


        public bool LoadText()
        {
            product.Clear();
            try
            {
                string[] lines;
                var list = new List<string>();
                var fileStream = new FileStream(fileNameTxt, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                foreach (string s in list)
                {
                    lines = list.ToArray();
                    Console.WriteLine(s);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool LoadJson()
        {
            product.Clear();
            try
            {
                
                string data = File.ReadAllText(fileNameJson);
                var tempProduct = JsonConvert.DeserializeObject<List<Product>>(data);
                foreach (Product t in tempProduct)
                {

                    product.Add(t);


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }



        public bool LoadExcel()
        {
            product.Clear();
            try
            {
                XSSFWorkbook hssfwb;
                using (FileStream file = new FileStream(fileNameExcel, FileMode.Open,
                FileAccess.Read))
                {
                    hssfwb = new XSSFWorkbook(file);
                }
                ISheet sheet = hssfwb.GetSheet("Mysheet");

                
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null)
                    {

                        int id = int.Parse(sheet.GetRow(row).GetCell(0).ToString());
                        string name = sheet.GetRow(row).GetCell(1).ToString();
                        double price = double.Parse(sheet.GetRow(row).GetCell(2).ToString());
                        int category = int.Parse(sheet.GetRow(row).GetCell(3).ToString());

                        Product a = new Product(id, name, price, category);
                        product.Add(a);
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void Print()
        {
            foreach (Product s in product)
            {
                Console.WriteLine(s);
            }
        }

        public override string ToString()
        {
            foreach (Product t in product)
            {
                Console.WriteLine($"id: {t.id}, name: {t.id}, price: {t.price}, category: {t.category}");
            }

            return "";
        }
    }
}

