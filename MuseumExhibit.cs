using System;
using System.IO;
using System.Text;

namespace lab3
{
    /// <summary>
    /// в классе MuseumExhibit содержится 5 полей различных типов для отображения характеристик экспоната.
    /// Затем определен конструктор для заполнения элемента класса, дальше идут 5 методов(GetAge, GetName, GetAgeOfAdmission, GetAuthorName и GetPrice) для получения значений из представителя класса.
    /// Под конец перегружается метод ToString для удобного вывода значения полей класса.
    /// </summary>
    public class MuseumExhibit
    {
        private string _name = "";
        private int _age = 0;
        private string _authorNameOrNoName = "";
        private int _ageOfAdmission = 0;
        private double _price = 0;

        public bool MuseumExhibitSetting(string name, string age, string authorNameOrNoName, string ageOfAdmission, string price)
        {
            double priceDouble = 0;
            int ageInt = 0;
            int ageOfAdmissionInt = 0;
            bool correct = false;
            while (correct == false)
            {
                try
                {
                    priceDouble = Double.Parse(price);
                    try
                    {
                        ageOfAdmissionInt = Int32.Parse(ageOfAdmission);
                        try
                        {
                            ageInt = Int32.Parse(age);
                            correct = true;
                            _name = name;
                            _authorNameOrNoName = authorNameOrNoName;
                            _age = ageInt;
                            _ageOfAdmission = ageOfAdmissionInt;
                            _price = priceDouble;
                        }
                        catch (FormatException)
                        {
                            return false;
                        }
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            if (priceDouble<0)
            {
                _price = 0;
                Console.WriteLine("Цена была отрицательной, программа поменяла его на 0");
            }
            if (_age>ageOfAdmissionInt)
            {
                _ageOfAdmission = _age;
                Console.WriteLine("Год добавления в музей был меньше года создания, программа поменяла его на год создания");
            }
            return true;
        }
        public int GetAge()//для показа значения 
        {
            return _age;
        }

        public string GetName()
        {
            return _name;
        }
        public string GetAutorName()
        {
            return _authorNameOrNoName;
        }
        public int GetAgeOfAdmission()
        {
            return _ageOfAdmission;
        }
        public double GetPrice()
        {
            return _price;
        }

        public override string ToString()//типо перегружен ToString
        {
            string age = _age + "";
            string ageOfAdmission = _ageOfAdmission + "";

            if (_age < 0)
            {
                age = -_age + " до нашей эры";
            }
            if (_ageOfAdmission < 0)
            {
                ageOfAdmission = -_ageOfAdmission + " до нашей эры";
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("Название: ").Append(_name)
                   .Append(", Год: ").Append(age)
                   .Append(", Автор: ").Append(_authorNameOrNoName)
                   .Append(", Год получения в музей: ").Append(ageOfAdmission)
                   .Append(", Цена: ").Append(_price);
            return builder.ToString();
        }
        public string ToString(double something)
        {
            string line = something + "";
            return line;
        }


    }
}
