using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Scriban;

namespace ScribanMVC
{
    public class ProductController
    {
        public List<Product> ProductList { get; set; }

        public ProductController()
        {
            ProductList = new List<Product>
            {
                new Product(){Name = "T-shirt", Price = 12.99},
                new Product(){Name = "Hat", Price = 9.99},
                new Product(){Name = "Gloves", Price = 1.99},
                new Product(){Name = "Skirt", Price = 9.99},
                new Product(){Name = "Bikini", Price = 15.99}
            };
        }

        public string ShowHtmlData()
        {
            string html = File.ReadAllText(@"E:\C#\Mef\ScribanMVC\View\ScribanMVC.html");

            var template = Template.Parse(html);

            return template.Render(new { Products = ProductList });
        }

        public void CreateHtmlFile(string html)
        {

            string filepath = @"E:\C#\Mef\ScribanMVC\View\" + "NewHTML.html";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            File.Create(filepath).Close();

            TextWriter tw = new StreamWriter(filepath, true);
            tw.WriteLine(html);
            tw.Close();
        }
    }
}
