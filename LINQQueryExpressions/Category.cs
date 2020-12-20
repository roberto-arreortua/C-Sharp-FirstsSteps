using System;
using System.Collections.Generic;
using System.Text;

namespace LINQQueryExpressions
{
    class Category
    {
        public string name;
        public Category(string pName)
        {
            this.name = pName;
        }
    }

    class Product
    {
        public string name;
        public Category category;

        public Product(string pName,Category pCategory)
        {
            this.category = pCategory;
            this.name = pName;
        }
    }
}
