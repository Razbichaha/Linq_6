﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_6
{
    //    Существует класс солдата.В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
    //Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
    //Вывести все полученные данные в консоль.
    //(Не менее 5 записей)
    class Program
    {
        static void Main(string[] args)
        {
            Barracks barracks = new Barracks();
            barracks.ShowSoldierData();
        }
    }

    class Barracks
    {
        private string[] _nameBase = { "Нестер", "Самиров"
                , "Рязанцев", "Геннадьевич", "Ксения"
                , "Романович", "Николай", "Петухина", "Вадим"
                , "Маргарита", "Точилкина", "Батраков", "Вязмитинова"
                , "Индейкина", "Колосюк", "Михаил", "Хорошилова"
                , "Павел", "Вероника", "Дмитрий", "Тельпугова"
                , "Биушкина", "Николай", "Александр", "Вероника"
                , "Ирина", "Тактаров", "Борис", "Полина"
                , "Спиридонов", "Лоринова", "Ряхин", "Юльева"
                , "Олег", "Глеб", "Тимофей", "Артур"};
        private string[] _nameWeaponBase = { "освященный жезл обезболивания","Конвергенция Валькирии Серебряногосвета", "Печальный Резчик"
                , "Туманный Скульптор","Железный нож Пустоты","Громовой Яростный Похититель золота","Винтерторн","Палач Ужаса"
                ,"Армагеддона","Воплощение СветовогоСкальпеля","Отражатель Деградации" };
        private string[] _rankSoldierBase = {"Хлунсид","Туирфар","Гексаджуппит","Атрафтур","Стиптирвин","Гексагилгунхид"
                ,"Изоирхечреасфазный","Моноспиарлирбиопсий","Брябадеопсол","Дифумнилаиптиол"};

        private List<Soldier> _soldiers = new List<Soldier>();


        public Barracks()
        {
            GenerateBarracks();
        }

        internal void ShowSoldierData()
        {

            Console.WriteLine("   Имя      Звание");
            Console.WriteLine();

            var soldierData = from soldier in _soldiers select (soldier.GetName(), soldier.GetRank());

            foreach (var data in soldierData)
            {
                Console.WriteLine(data);
            }

            Console.ReadLine();
        }

        private void GenerateBarracks()
        {
            int quantitySoldiers = 25;

            for (int i = 0; i < quantitySoldiers; i++)
            {
                Soldier soldier = new Soldier(GenerateNameSoldier(), GenerateWeaponSoldier(), GenerateRankSoldier(), GenerateTimeServed());
                _soldiers.Add(soldier);
            }
        }

        private int GenerateTimeServed()
        {
            Random random = new Random();
            int maximumRankServed = 20;
            int minimumRankServed = 2;

            int rankServed = random.Next(minimumRankServed, maximumRankServed);
            return rankServed;
        }

        private string GenerateRankSoldier()
        {
            Random random = new Random();
            return _rankSoldierBase[random.Next(_rankSoldierBase.Length)];
        }

        private string GenerateWeaponSoldier()
        {
            Random random = new Random();
            return _nameWeaponBase[random.Next(_nameWeaponBase.Length)];
        }

        private string GenerateNameSoldier()
        {
            Random random = new Random();
            return _nameBase[random.Next(_nameBase.Length)];
        }
    }

    class Soldier
    {
        private string _name;
        private string _weapon;
        private string _rank;
        private int _timeServed;

        public Soldier(string name, string weapon, string rank, int timeServed)
        {
            _name = name;
            _weapon = weapon;
            _rank = rank;
            _timeServed = timeServed;
        }

        internal string GetName()
        {
            return _name;
        }
        internal string GetWeapon()
        {
            return _weapon;
        }
        internal string GetRank()
        {
            return _rank;
        }
        internal int GetTimeServed()
        {
            return _timeServed;
        }
    }
}