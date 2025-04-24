using System;
using System.IO;
using System.Text;

namespace lab3
{
    public class MuseumExhibit//основной класс 
    {
        private string _name = "";
        private int _age = 0;
        private string _authorNameOrNoName = "";
        private int _ageOfAdmission = 0;
        private double _price = 0;

        public MuseumExhibit(string name, int age, string authorNameOrNoName, int ageOfAdmission, double price)
        {
            _name = name;
            _age = age;
            _authorNameOrNoName = authorNameOrNoName;
            _ageOfAdmission = ageOfAdmission;
            _price = price;
            if (age>ageOfAdmission)
            {
                _ageOfAdmission = age;
            }
            if (price<0)
            {
                _price = 0;
            }
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
            StringBuilder builder = new StringBuilder();
            builder.Append("Название: ").Append(_name)
                   .Append(", Год: ").Append(_age)
                   .Append(", Автор: ").Append(_authorNameOrNoName)
                   .Append(", Год получения в музей: ").Append(_ageOfAdmission)
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
