using System;

namespace No2
{
    public class Broker 
    {
        public string Name { get; set; }

        public Broker(string name) => Name = name;

        public void Register(Stock stock) => stock.StockChanged += Update;

        public void Unregister(Stock stock) => stock.StockChanged -= Update;

        public void Update(object sender, StockInfoEventArgs info)
        {
            Console.WriteLine(
                info.USD > 30
                    ? $"Broker {this.Name} sells dollars; Dollar rate: {info.USD}"
                    : $"Broker {this.Name} buys dollars; Dollar rate: {info.USD}");
        }
    }
}
