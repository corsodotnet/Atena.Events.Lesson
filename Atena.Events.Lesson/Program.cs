using System;

namespace Atena.Events.Lesson
{   
    public delegate void StockDelegate(object sender, StockEventArgs e);  

    public class StockEventArgs : EventArgs
    {
        public string _message;
        public StockEventArgs(string Msg)
        {
            _message = Msg; 
        }
    }

    internal class Program
    {
        static StockDelegate stockDel;
        static void Main(string[] args)
        {
            stockDel = new StockDelegate(NotifierMonitor);
            Stock tesla = new Stock();
            tesla.Name = "PUTIN";
            tesla.TempDel += stockDel;            
            tesla.Prezzo = 20;
            tesla.Prezzo = 22;
        }
        static void NotifierMonitor(object sender, StockEventArgs e)
        {
           
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e._message);
            Console.ResetColor();
        }
    } 
    public class Stock
    {   
        public string Name { get; set; }
        public StockEventArgs TempEventArgs;
        public event StockDelegate TempDel;

        decimal _prezzo;  
        public decimal Prezzo { get { return _prezzo; } 
            set 
            {
                if ((_prezzo != value) && (TempDel != null))
                {
                  
                    TempEventArgs = new StockEventArgs($"Il valore di {Name} ora è {value}");
                    TempDel(this, TempEventArgs);  
                    this._prezzo = value;
                }
            } 
        }  
        
        
    }
}
