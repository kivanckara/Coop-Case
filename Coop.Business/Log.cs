using Coop.Business.Event;
using System;

namespace Coop.Business
{
    public class Log
    {
        public void Subscribe(Coop breed)
        {
            breed.BreedProcess += NewChildLog;
        }

        private void NewChildLog(object sender, KindEventArgs e)
        {
            Console.WriteLine($"{e.Count} {e.Gender} {e.Name}s borned");
        }
    }
}