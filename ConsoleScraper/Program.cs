using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Scrape.scrapeData();

            /*using (var db = new StockContext())
            {
                db.Stocks.Add(new StockContext.Stock());
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All stocks in database");
                foreach(var stock in db.Stocks)
                    Console.WriteLine(" - {0}", stock.Symbol);
            }*/
        }
    }
}
