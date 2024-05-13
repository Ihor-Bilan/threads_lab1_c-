using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Start();
        }

        void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введіть кількість потоків:");
            int threadCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() => Calculator(i + 1)); // Передача індексу потоку
                thread.Start();
                Thread.Sleep(100); // Без затримки індекси хаотичні
            }

            Stoper();
        }

        void Calculator(int threadNumber)
        {
            long sum = 0;
            long additionsCount = 0; 
            do
            {
                sum+=5;
                additionsCount++;
            }
            while (!CanStop);
            Stoper();
            Console.WriteLine($"Потік {threadNumber} сума: {sum}, Кількість доданків: {additionsCount}");
        }

        private bool canStop = false;

        public bool CanStop { get => canStop; }

        public void Stoper()
        {
            Thread.Sleep(1000);
            canStop = true;
        }
    }
}
