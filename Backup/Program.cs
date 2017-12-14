using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            const int STORAGE_SIZE = 3;
            Storage[] storage = new Storage[STORAGE_SIZE];
            storage[0] = new Flash("FLASH", "FLASH2000", 8000, 0, 20);
            storage[1] = new DVD("DVD", "DVD3000", 10, true, 9000, 0);
            storage[2] = new HDD("HDD", "HDD4000", 10000, 10, 100000, 0, 10);

            bool switchForWhile = true;
            int h = 0;
            while (switchForWhile)
            {
                Console.WriteLine("0- Выход");
                Console.WriteLine("1- Расчет общего количества памяти всех устройств");
                Console.WriteLine("2- Копирование информации на устройства");
                Console.WriteLine("3- Расчет времени необходимого для копирования");
                Console.WriteLine("4- Расчет необходимого количества носителей информации представленных типов для переноса информации");
                h = int.Parse(Console.ReadLine());
                switch (h)
                {
                    case 0: switchForWhile = false; break;
                    case 1: GetAllMemory(storage); break;
                    case 2: CopyInformation(storage); break;
                    case 3: GetTimeCopy(storage); break;
                    case 4: GetCountStorage(storage); break;
                }
            }
        }

        static void GetAllMemory(Storage[] storage)//1 method
        {
            int AllMemory = 0;
            for (int i = 0; i < storage.Length; i++)
            {
                AllMemory = AllMemory + storage[i].GetMemory();
            }
            Console.WriteLine("Общая память всех устройств; " + AllMemory + " мб.");
        }

        static void CopyInformation(Storage[] storage)//2 method
        {
            Console.WriteLine("Введите размер информации которую вы хотите скопировать");
            int requiredAmountOfMemory = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите наименование носитель на который вы хотите скопировать информацию");
            string requiredName = Console.ReadLine();

            bool switchForFor = false;
            for (int i = 0; i < storage.Length; i++)
            {
                if (requiredName == storage[i].GetName())
                {
                    switchForFor = true;
                    if (storage[i].GetMemory() >= requiredAmountOfMemory)
                    {
                        storage[i].FillMemory(requiredAmountOfMemory);
                        Console.WriteLine("Информация успешно скопирована");
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно места на носителе");
                    }
                }
            }
            if (switchForFor == false)
            {
                Console.WriteLine("Носитель с таким именем не найден");
            }
            Console.ReadLine();
        }

        static void GetTimeCopy(Storage[] storage)//3 method
        {
            Console.WriteLine("Введите размер информации которую вы хотите скопировать");
            int requiredAmountOfMemory = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите наименование носитель на который вы хотите скопировать информацию");
            string requiredName = Console.ReadLine();

            bool switchForFor = false;
            for (int i = 0; i < storage.Length; i++)
            {
                if (requiredName == storage[i].GetName())
                {
                    switchForFor = true;
                    if (storage[i].GetMemory() >= requiredAmountOfMemory)
                    {
                        Console.WriteLine("На загрзку информации уйдет; " + (requiredAmountOfMemory / storage[i].GetSpeed()) + " мин.");
                    }
                    else
                    {
                        Console.WriteLine("Не достаточно места на носителе");
                    }
                }
            }
            if (switchForFor == false)
            {
                Console.WriteLine("Носитель с таким именем не найден");
            }
            Console.ReadLine();
        }

        static void GetCountStorage(Storage[] storage)//4 method
        {
            Console.WriteLine("Введите размер информации которую вы хотите скопировать");
            int requiredAmountOfMemory = int.Parse(Console.ReadLine());
            for (int i = 0; i < storage.Length; i++)
            {
                Console.WriteLine("Вам понадобится; " + ((requiredAmountOfMemory - ((requiredAmountOfMemory % storage[i].GetMemory())) / requiredAmountOfMemory) + 1) + " " + storage[i].GetName());
            }
        }
    }
}
