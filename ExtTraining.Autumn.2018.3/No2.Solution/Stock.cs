using System;
using System.Collections.Generic;

namespace No2
{
    public class Stock
    {
        public event EventHandler<StockInfoEventArgs> StockChanged;
        
        public void Market()
        {
            Random rnd = new Random();

            OnStockChanged(info: new StockInfoEventArgs() { USD = rnd.Next(20, 40), Euro = rnd.Next(30, 50) });
        }

        protected virtual void OnStockChanged(StockInfoEventArgs info) 
            => StockChanged?.Invoke(this, info);
    }
}
