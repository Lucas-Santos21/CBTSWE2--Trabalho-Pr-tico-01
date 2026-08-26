//Nome e prontuário da dupla:
//Lucas da Silva Santos CB3030598
//Kaueh Farias Ferreira dos Santos CB3031438


using System;
using System.Collections.Generic;
using System.Text;
using TP01_SistemasWeb2.Data;

namespace TP01_SistemasWeb2.Models
{
    public class Book
    {
        private string name;
        private Author[] authors;
        private double price;
        private int qty = 0;

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string GetName()
        {
            return name;
        }

        public Author[] GetAuthors()
        {
            return authors;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public int GetQty()
        {
            return qty;
        }

        public void SetQty(int qty)
        {
            this.qty = qty;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Book[name={name},authors={{");

            for (int i = 0; i < authors.Length; i++)
            {
                result.Append(authors[i].ToString());

                if (i < authors.Length - 1)
                {
                    result.Append(",");
                }
            }

            result.Append($"}},price={price:F2},qty={qty}]");

            return result.ToString();
        }

        public string GetAuthorNames()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < authors.Length; i++)
            {
                result.Append(authors[i].GetName());

                if (i < authors.Length - 1)
                {
                    result.Append(",");
                }
            }

            return result.ToString();
        }
    }
}
