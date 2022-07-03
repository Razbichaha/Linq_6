using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_6
{
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

            var soldierData = from soldier in _soldiers select (soldier.Name, soldier.Rank);

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
        internal string Name { get ;private set ; }
        internal string Weapon { get ;private set ; }
        internal string Rank { get;private set; }
        internal int TimeServed { get ;private set ; }

        public Soldier(string name, string weapon, string rank, int timeServed)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            TimeServed = timeServed;
        }
    }
}
