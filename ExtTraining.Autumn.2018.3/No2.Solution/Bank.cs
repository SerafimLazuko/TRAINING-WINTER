using System;

namespace No2
{
    public class Bank
    { 
        public string Name { get; set; }

        public Bank(string name) => this.Name = name;

        public void Register(Stock stock) => stock.StockChanged += Update;

        public void Unregister(Stock stock) => stock.StockChanged -= Update;

        public void Update(object sender, StockInfoEventArgs info)
        {
            Console.WriteLine(
                info.Euro > 40
                    ? $"Bank {this.Name} sells euros; Euro rate:{info.Euro}"
                    : $"Bank {this.Name} is buying euros; Euro rate: {info.Euro}");
        }
    }
}
