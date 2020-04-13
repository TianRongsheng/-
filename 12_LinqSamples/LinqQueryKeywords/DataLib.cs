using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqQueryKeywords
{
    public static class DataLib
    {
        public static List<Student> InitializeStudent()
        {
            List<Student> students = new List<Student>
            {
             new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int>() {97, 92, 81, 60}},
             new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int>() {75, 84, 91, 39}},
             new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int>() {88, 94, 65, 91}},
             new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int>() {97, 89, 85, 82}},

            };
            return students;
        }
        public static List<ContactInfo> InitializeContacts()
        {
            List<ContactInfo> contactList = new List<ContactInfo>()
        {
            new ContactInfo {ID=111, Email="SvetlanO@Contoso.com", Phone="206-555-0108"},
            new ContactInfo {ID=112, Email="ClaireO@Contoso.com", Phone="206-555-0298"},
            new ContactInfo {ID=113, Email="SvenMort@Contoso.com", Phone="206-555-1130"},
            new ContactInfo {ID=114, Email="CesarGar@Contoso.com", Phone="206-555-0521"}
        };
            return contactList;
        }
        public static List<Category> InitializeCategories()
        {
            List<Category> categories = new List<Category>()
             {
                   new Category {Name="Beverages", ID=001},
                   new Category {Name="Condiments", ID=002},
                   new Category {Name="Vegetables", ID=003},
                   new Category {Name="Grains", ID=004},
                   new Category {Name="Fruit", ID=005}
             };
            return categories;
        }


        public static List<Product> InitializeProducts()
        {
            List<Product> products = new List<Product>()
              {
                 new Product {Name="Cola",  CategoryID=001},
                 new Product {Name="Tea",  CategoryID=001},
                 new Product {Name="Mustard", CategoryID=002},
                 new Product {Name="Pickles", CategoryID=002},
                 new Product {Name="Carrots", CategoryID=003},
                 new Product {Name="Bok Choy", CategoryID=003},
                 new Product {Name="Peaches", CategoryID=005},
                 new Product {Name="Melons", CategoryID=005},
               };
            return products;
        }
    }
}
