using Catalog.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            StreamReader readerCategories, readerProducts;
            
            try
            {
                readerCategories = new StreamReader(File.OpenRead(@"Files\\Categories.csv"));
                readerProducts = new StreamReader(File.OpenRead(@"Files\\Products.csv"));

                List<Category> categories = new List<Category>();
                List<Product> products = new List<Product>();

                Console.WriteLine("Conviertiendo a JSON y XML....");

                string header_category_file = readerCategories.ReadLine();

                while (!readerCategories.EndOfStream)
                {
                    Category category = new Category();

                    string cateogry_line = readerCategories.ReadLine();
                    string[] category_values = cateogry_line.Split(';');


                    category.Id = Convert.ToInt32(category_values[0]);
                    category.Name = category_values[1];
                    category.Description = category_values[2];

                    string header_product_file = readerProducts.ReadLine();

                    while (!readerProducts.EndOfStream)
                    {
                        Product product = new Product();

                        string product_line = readerProducts.ReadLine();
                        string[] product_values = product_line.Split(';');

                        if (category.Id == Convert.ToInt32(product_values[1]))
                        {
                            product.Id = Convert.ToInt32(product_values[0]);
                            product.CategoryId = Convert.ToInt32(product_values[1]);
                            product.Name = product_values[2];
                            product.Price = Convert.ToDouble(product_values[3]);

                            products.Add(product);
                        }
                    }

                    category.Products = products;
                    categories.Add(category);
                }

                // Serialize JSON and write file
                using (StreamWriter file = File.CreateText(@"Catalog.json"))
                {
                    JsonSerializer serializerJson = new JsonSerializer();
                    serializerJson.Serialize(file, categories);
                }

                // Serialize XML and write file
                using (StreamWriter file = File.CreateText(@"Catalog.xml"))
                {
                    XmlSerializer serializerXml = new XmlSerializer(typeof(List<Category>));
                    serializerXml.Serialize(file, categories);
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Fichero no encontrado", e);
                throw;
            } finally
            {
                Console.WriteLine("Ficheros creados en " + path + ". Pulse cualquier tecla para salir.");
                Console.ReadLine();
            }
            

            
        }
    }
}
