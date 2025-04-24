using lab3;
using System;
using System.IO;
using static System.Reflection.Metadata.BlobBuilder;


internal class Program
{
    public static void Main()
    {
        bool globalFlag = false;

        RequestForMuseumExhibit generalBase = new RequestForMuseumExhibit();
        generalBase.DataBaseFromFileBinary();

        while (globalFlag == false)
        {
            Console.WriteLine("--- Музейные экспонаты ---");
            Console.WriteLine("1. Просмотреть экспонаты");
            Console.WriteLine("2. Добавить экспонат");
            Console.WriteLine("3. Списать экспонат");
            Console.WriteLine("4. Запрос по цене");
            Console.WriteLine("5. Запрос по автору");
            Console.WriteLine("6. Число экспонатов до нашей эры");
            Console.WriteLine("7. Число экспонатов в музее");
            Console.WriteLine("q. Выход");
            Console.Write("Выберите действие: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1"://просмотр базы
                    generalBase.ViewDataBase();
                    break;
                case "2"://добавление элемента
                    bool correct = false;

                    string name = "";
                    string age = "";
                    string author = "";
                    string ageOfAdmission = "";
                    string price = "";

                    int ageInt = 0;
                    int ageOfAdmissionInt = 0;
                    double priceDouble = 0;
                    while (correct == false)
                    {
                        Console.Write("Введите название экспоната: ");
                        name = Console.ReadLine();
                        Console.Write("Введите год создания экспоната: ");
                        age = Console.ReadLine();
                        Console.Write("Введите имя автора экспоната: ");
                        author = Console.ReadLine();
                        Console.Write("Введите год поступления экспоната в музей: ");
                        ageOfAdmission = Console.ReadLine();
                        Console.Write("Введите стоимость экспоната: ");
                        price = Console.ReadLine();
                        ageInt = 0;
                        ageOfAdmissionInt = 0;
                        priceDouble = 0;


                        try
                        {
                            ageInt = Int32.Parse(age);
                            try
                            {
                                ageOfAdmissionInt = Int32.Parse(ageOfAdmission);
                                try
                                {
                                    priceDouble = Double.Parse(price);
                                    correct = true;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("стоимость не число, введи еще раз");
                                }

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("дата добавления не число, введи еще раз");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("дата не число, введи еще раз");
                        }
                    }

                    MuseumExhibit newExhibit = new MuseumExhibit(name, ageInt, author, ageOfAdmissionInt, priceDouble);

                    generalBase.AddToDataBase(newExhibit);
                    break;
                case "3"://удаление элемента
                    Console.Write("Введите название экспоната который хотите списать: ");
                    name = Console.ReadLine();

                    generalBase.DeleteFromDataBase(name);
                    break;
                case "4"://стоимость меньше заданной
                    price = "";
                    priceDouble = 0;
                    correct = false;
                    while (correct == false)
                    {
                        Console.Write("Введите стоимость экспоната: ");
                        price = Console.ReadLine();
                        try
                        {
                            priceDouble = Double.Parse(price);
                                correct = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("стоимость не число, введи еще раз: ");
                        }
                    }
                    generalBase.CheckPrice(priceDouble);
                    break;

                case "5"://все экспонаты одного автора
                    
                    Console.Write("Введите имя автора: ");
                    author = Console.ReadLine();
                    generalBase.CheckAuthor(author);
                    break;
                case "6"://число экспонатов до нашей эры возрастом
                    generalBase.CheckAge();
                    break;
                case "7"://всего экспонатов
                    generalBase.NumberOfExhibits();
                    break;
                case "q"://выход
                    generalBase.DataBaseToFileBinary();
                    globalFlag = true;
                    break;
                default://ошибка
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
