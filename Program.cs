using System;
using System.Collections.Generic;
using System.Linq;

namespace WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit.Work();
        }
    }

    class MilitaryUnit
    {
        private List<Soldier> _soldiers;

        public MilitaryUnit()
        {
            SoldierCreator soldierCreator = new SoldierCreator();
            int soldiersCount = 10;

            _soldiers = soldierCreator.CreateSoldiers(soldiersCount);
        }

        public void Work()
        {
            ConsoleOutputMethods.WriteRedText("Полная информация о солдатах");
            ShowFullSoldierInfo();

            ConsoleOutputMethods.WriteRedText("Краткая информация о солдатах");
            ShowNamesAndRanks();
        }

        private void ShowFullSoldierInfo()
        {
            foreach (var soldierInfo in _soldiers)
            {
                Console.WriteLine($"{soldierInfo.FullName}\n" +
                    $"{soldierInfo.Weapon}\n" +
                    $"{soldierInfo.Rank}\n" +
                    $"Месяцев на службе - {soldierInfo.ServiceTerm}\n");
            }
        }

        private void ShowNamesAndRanks()
        {
            var soldiersList = _soldiers
                .Select(soldier => soldier.FullName + "\n" + soldier.Rank)
                .ToList();

            foreach (var soldierInfo in soldiersList)
            {
                Console.WriteLine(soldierInfo + "\n");
            }
        }
    }

    class Soldier
    {
        public Soldier(string fullName, string weapon, string rank, int serviceTerm)
        {
            FullName = fullName;
            Weapon = weapon;
            Rank = rank;
            ServiceTerm = serviceTerm;
        }

        public string FullName { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTerm { get; private set; }
    }

    class SoldierCreator
    {
        private List<string> _names;
        private List<string> _weapons;
        private List<string> _ranks;

        public SoldierCreator()
        {
            _names = new List<string>
            {
                "Пупкин Василий Викторович",
                "Сафронов Алексей Николаевич",
                "Табуретов Биба Васильевич",
                "Табуретов Боба Васильевич",
                "Котофеев Нурлан Барсикович",
                "Рыбаков Александр Юрьевич",
                "Владимиров Владимир Владимирович"
            };

            _weapons = new List<string>
            {
                "AK-74M",
                "AK-12",
                "AK-47U"
            };

            _ranks = new List<string>
            {
                "Recruit",
                "Corporal"
            };
        }

        public List<Soldier> CreateSoldiers(int count)
        {
            Random random = new Random();
            List<Soldier> soldiers = new List<Soldier>();

            int maxServiceTerm = 12;

            for (int i = 0; i < count; i++)
            {
                soldiers.Add(new Soldier(_names[random.Next(0,_names.Count)],
                    _weapons[random.Next(0, _weapons.Count)],
                    _ranks[random.Next(0, _ranks.Count)],
                    random.Next(0, maxServiceTerm)));
            }

            return soldiers;
        }
    }

    static class ConsoleOutputMethods
    {
        public static void WriteRedText(string text)
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = tempColor;
        }
    }
}
