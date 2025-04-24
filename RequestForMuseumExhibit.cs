using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace lab3
{
    public class RequestForMuseumExhibit // класс запросов для базы
    {
        private const string binaryFilename = "C:/Users/алексей/Desktop/aboba.txt";//файлик менять можно только ручками

        Dictionary<string, MuseumExhibit> dataBase = new Dictionary<string, MuseumExhibit>();//это словарик - база

        public void DataBaseToFileBinary()//заполнение бинарного файла
        {
            using BinaryWriter file = new BinaryWriter(File.Open(binaryFilename, FileMode.OpenOrCreate));
            {
                var someExhibits = from p in dataBase select p.Value;

                foreach (MuseumExhibit i in someExhibits)
                {


                    string name = i.GetName();
                    int age = i.GetAge();
                    string author = i.GetAutorName();
                    int ageOfAdmission = i.GetAgeOfAdmission();
                    double price = i.GetPrice();

                    file.Write(name);
                    file.Write(age);
                    file.Write(author);
                    file.Write(ageOfAdmission);
                    file.Write(price);
                }
                file.Close();
            }
        }

        public void DataBaseFromFileBinary()//считывание из бинарного файла
        {
            using BinaryReader file = new BinaryReader(File.Open(binaryFilename, FileMode.OpenOrCreate));
            {
                try
                {
                    dataBase.Clear();

                    bool finishFile = false;
                    while (finishFile == false)
                    {
                        try
                        {
                            string name = file.ReadString();
                            int age = file.ReadInt32();
                            string author = file.ReadString();
                            int ageOfAdmission = file.ReadInt32();
                            double price = file.ReadDouble();

                            MuseumExhibit someToDataBase = new MuseumExhibit(name, age, author, ageOfAdmission, price);

                            dataBase.Add(name, someToDataBase);
                        }
                        catch
                        {
                            finishFile = true;
                        }
                    }
                    file.Close();

                }
                catch
                {
                    Console.WriteLine("Error");
                    string[] result = { "Error" };
                    dataBase.Clear();
                }

            }

        }

        public void ViewDataBase()//показать базу
        {
            var someExhibits = from p in dataBase select p.Value;

            Console.WriteLine("Вот ваша база");
            foreach(MuseumExhibit i in someExhibits)
            {
                string line = i.ToString();
                Console.WriteLine(line);
            }
        }

        public void AddToDataBase(MuseumExhibit newExhibit)//добавить в базу
        {
            string name = newExhibit.GetName();

            if (dataBase.ContainsKey(name))
            {
                Console.WriteLine("Такой элемент с таким именем уже есть в базе, нельзя добавить");
            }
            else
            {
                dataBase.Add(name, newExhibit);
                Console.WriteLine("Экспонат добавлен в базу данных");
            }
        }

        public void DeleteFromDataBase(string name)//удалить из базы по имени
        {

            if (dataBase.ContainsKey(name))
            {
                dataBase.Remove(name);
                Console.WriteLine("Экспонат удален");
            }
            else
            {
                Console.WriteLine("Экспоната с таким названием нет в музее");
            }
        }

        public IEnumerable<MuseumExhibit> CheckPrice(double price)//посмотреть экспонаты меняьше указанной стоимости
        {
            var someExhibits = from p in dataBase where p.Value.GetPrice() < price select p.Value;
            if (someExhibits.Any(p => p.GetPrice()<price))
            {
                Console.WriteLine("Вот экспонаты, у которых цена ниже указанной");
                foreach (MuseumExhibit i in someExhibits)
                {
                    string line = i.ToString();
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Экземпляров ниже данной цены нет в музее");

            }
            return someExhibits;
        }

        public IEnumerable<MuseumExhibit> CheckAuthor(string authorName)//экспанаты с одним автором
        {
            var someExhibits = from p in dataBase where p.Value.GetAutorName() == authorName select p.Value;
            if (someExhibits.Any(p => p.GetAutorName() == authorName))
            {
                Console.WriteLine("Вот экспонаты, у которых данный автор");
                foreach (MuseumExhibit i in someExhibits)
                {
                    string line = i.ToString();
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Экземпляров с таким автором нет в музее");
            }
            return someExhibits;
        }

        public int CheckAge()//все экспонаты до нашей эры созданные
        {
            var someExhibits = from p in dataBase where p.Value.GetAge() < 0 select p.Value;
            int counter = 0;
            foreach (MuseumExhibit i in someExhibits)
            {
                counter++;
            }
            Console.WriteLine("Число экспонатов, созданных до нашей эры: " + counter);
            return counter;
        }

        public int NumberOfExhibits()//число всех экспонатов
        {
            var someExhibits = from p in dataBase select p.Value;
            int counter = 0;
            foreach (MuseumExhibit i in someExhibits)
            {
                counter++;
            }
            Console.WriteLine("Число экспонатов в музее: " + counter);
            return counter;
        }
    }
}
