using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string MutexName = "RUNMEONCE";

            try
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("Cannot open the mutex because it doesn't exist");
            }

            
            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
                Console.WriteLine("Mutex created.");
            }
            else
            {
                oneMutex.Close();
                Console.WriteLine("Mutex closed.");
                return;
            }

            Console.Read();
        }
    }
}
