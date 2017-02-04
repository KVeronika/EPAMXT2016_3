using System;

namespace XT2016_3.Auction.Entities
{
    public class Product
    {
        public Product(int id, string name, string description, decimal currentRate, DateTime endingDate, bool buyNow)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.CurrentRate = currentRate;
            this.EndingDate = endingDate;
            this.BuyNow = buyNow;
        }

        public Product(string name, string description, decimal currentRate, DateTime endingDate, bool buyNow)
        {
            this.Name = name;
            this.Description = description;
            this.CurrentRate = currentRate;
            this.EndingDate = endingDate;
            this.BuyNow = buyNow;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CurrentRate { get; set; }

        public DateTime EndingDate { get; set; }

        public bool BuyNow { get; set; }
    }
}