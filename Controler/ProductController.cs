using Scriban;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            CreateHtmlFile();
        }

        public void CreateHtmlFile()
        {
            string html = CreateHtmlText();

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "ScribanMVC.html";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            File.Create(filepath).Close();           

            TextWriter tw = new StreamWriter(filepath, true);
            tw.WriteLine(html);
            tw.Close();            
        }

        public string CreateHtmlText()
        {
            var template = Template.Parse(@"
            <ul id='products'>
                {{ for product in products }}
                <li>
                    <h2>{{ product.name }}</h2>
                    Price : {{ product.price }}
                </li>
                {{ end }}
            </ul>
            ");
            var result = template.Render(new { Products = ProductList });
            return result;
        }
    }
}