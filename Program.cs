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
            ShowFullSoldierInfo(_soldiers);

            ConsoleOutputMethods.WriteRedText("Краткая информация о солдатах");
            ShowNamesAndRanks(_soldiers);
        }

        private void ShowFullSoldierInfo(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.FullName}\n" +
                    $"{soldier.Weapon}\n" +
                    $"{soldier.Rank}\n" +
                    $"Месяцев на службе - {soldier.ServiceTerm}\n");
            }
        }

        private void ShowNamesAndRanks(List<Soldier> soldiers)
        {
            var soldiersList = soldiers.Select(soldier => new
            {
                FullName = soldier.FullName,
                Rank = soldier.Rank
            }).ToList();

            soldiersList.ForEach(soldier => Console.WriteLine($"{soldier.FullName}\n" +
                    $"{soldier.Rank}\n"));
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
                soldiers.Add(new Soldier(_names[random.Next(0, _names.Count)],
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