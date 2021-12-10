using System;
using System.Linq;

namespace SCReport
{
    class Program
    {
        static public void Main()
        {
            using(var context = new HistoryContext())
            {
                var history = context.History.ToList();
                foreach(var item in history)
                    Console.WriteLine($"{item.PtId}\t{item.MDate}\t{item.MValue}");
            }
            
        }
    }
}