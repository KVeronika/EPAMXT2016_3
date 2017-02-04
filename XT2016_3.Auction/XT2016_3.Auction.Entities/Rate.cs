using System;

namespace XT2016_3.Auction.Entities
{
    public class Rate
    {
        public Rate(int ProductId, decimal rate)
        {
            this.ProductId = ProductId;
            this.Cost = rate;
        }

        public Rate(int userId, int ProductId, decimal rate)
        {
            this.UserId = userId;
            this.ProductId = ProductId;
            this.Cost = rate;
        }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public decimal Cost { get; set; }
    }
}