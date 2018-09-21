using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScraper
{
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=.\\stock.db");
        }

        public class Stock
        {
            public int Id { get; set; }
            public string Symbol { get; set; }
            public string LastPrice { get; set; }
            [Display(Name="% Change")]
            public string PercentChange { get; set; }
            public string Currency { get; set; }
            public string MarketTime { get; set; }
            public string Volume { get; set; }
            public string Shares { get; set; }
            public string AvgVol3m { get; set; }
            public string MarketCap { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
