using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorts
{
    class Program
    {
        static void Main(string[] args)
        {

            int n;
            int a = 0;

            Random rand = new Random();
            Console.Write("Введите размерность массива: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(-1000, 1000);
                Console.Write(mas[i]);
                Console.Write("     ");
                a++;
                if (a == 6)
                {
                    Console.Write("\n");
                    a = 0;
                }
            }

            Console.Write("\n");
            Console.Write("\n");
            Console.Write("\n");
            int choose;
            Console.Write("Введите какую сортировку использовать (1 - Quick sort, 2 - Heap sort): ");
            choose = Convert.ToInt32(Console.ReadLine());



            if (choose == 1)
            {
                Console.WriteLine("Отсортированный массив с Quick sort:");
                a = 0;
                mas = QuickSort(mas, 0, mas.Length - 1);

                for (int i = 0; i < mas.Length; i++)
                {

                    Console.Write(mas[i]);
                    Console.Write("     ");
                    a++;
                    if (a == 6)
                    {
                        Console.Write("\n");
                        a = 0;
                    }
                }

            }else if(choose == 2)
            {
                a = 0;
                heapSort(mas, n);
                Console.WriteLine("Отсортированный массив c Heap Sort: ");
                for (int i = 0; i < n; i++)
                    {
                        Console.Write(mas[i]);
                        Console.Write("     ");
                        a++;
                        if (a == 6)
                        {
                            Console.Write("\n");
                            a = 0;
                        }
                }
            
            }


        





            Console.ReadLine();
        }



        //quick sort
        static int FindPivot(int[] mas, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            int temp = 0;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (mas[i] < mas[maxIndex])
                {
                    pivot++;
                    temp = mas[pivot];
                    mas[pivot] = mas[i];
                    mas[i] = temp;

                }
            }

            pivot++;
            temp = mas[pivot];
            mas[pivot] = mas[maxIndex];
            mas[maxIndex] = temp;


            return pivot;
        }


        static int[] QuickSort(int[] mas, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return mas;
            }
            int pivot = FindPivot(mas, minIndex, maxIndex);
            QuickSort(mas, minIndex, pivot - 1);
            QuickSort(mas, pivot + 1, maxIndex);

            return mas;
        }





        //heap sort
        static void heapSort(int[] mas, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(mas, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = mas[0];
                mas[0] = mas[i];
                mas[i] = temp;
                heapify(mas, i, 0);
            }
        }
        static void heapify(int[] mas, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && mas[left] > mas[largest])
                largest = left;
            if (right < n && mas[right] > mas[largest])
                largest = right;
            if (largest != i)
            {
                int swap = mas[i];
                mas[i] = mas[largest];
                mas[largest] = swap;
                heapify(mas, n, largest);
            }
        }
    }
}
