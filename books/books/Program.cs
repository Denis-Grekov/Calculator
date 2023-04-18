using System;
using System.Threading;

class Program
{
    static SemaphoreSlim semaphore; 
    static int numReaders; 
    static Random random = new Random(); 

    static void Main(string[] args)
    {
        Console.Write("Введите количество читателей (N): ");
        if (!int.TryParse(Console.ReadLine(), out numReaders))
        {
            Console.WriteLine("Некорректное значение. Попробуйте еще раз.");
            return;
        }
        
            semaphore = new SemaphoreSlim(2);

            for (int i = 0; i < numReaders; i++)
            {
                Reader reader = new Reader(i + 1);
                Thread readerThread = new Thread(reader.ReadBooks); // Создание потоков для работы читателей
                readerThread.Start();
            }

        Console.ReadLine();
    }

    class Reader
    {
        private int readerId; 
        private int numVisits; 

        public Reader(int id)
        {
            readerId = id;
            numVisits = 0;
        }

        public void ReadBooks()
        {

            

            while (numVisits < 2) 
            {
                Console.WriteLine($"Читатель {readerId} пришел в библиотеку.");
                semaphore.Wait();

                

                Console.WriteLine($"Читатель {readerId} зашел в библиотеку и начал читать.");

                
                Thread.Sleep(random.Next(1000, 5000));

                Console.WriteLine($"Читатель {readerId} закончил читать и покинул библиотеку.");

                semaphore.Release(); // Освобождение разрешения на вход в библиотеку


                numVisits++; 

                
                Thread.Sleep(random.Next(1000, 5000));
            }
        }
    }
}
