using System;
namespace No2
{
    public class StockInfoEventArgs : EventArgs
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }
}
