using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace SimGame
{
    internal class Program
    {
        public static AVirus HirosumaVirus => new Hiroshima("Hiroshima", false, 0.75f, 0.7f);
        private static int CountPersons;
        private static int MaxDays;
        private static Action<Simulator> ShowInfo = (simulator) =>
        {
            Console.WriteLine($"Погибло: {simulator.CountDead}\nПопуляция: {simulator.CountAlivePerson}\nЗаболевших: {simulator.FallIll}\nВыздоровевших: {simulator.Recovered}");
            if (simulator.Days < simulator.MaxDays)
                Console.WriteLine($"Дней прошло: {simulator.Days}");
        };

        private static Action inputDate = () =>
        {
            Console.WriteLine("Введите количество людишек:");
            CountPersons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество дней:");
            MaxDays = Convert.ToInt32(Console.ReadLine());
        };

        static void Main(string[] args)
        {
            inputDate();
            Simulator simulator = new Simulator(CountPersons, MaxDays, HirosumaVirus);
            Observer observer = new Observer(ref simulator);
            observer.Start();
            Results(simulator);
        }

        private static void Results(Simulator simulator)
        {
            ShowInfo(simulator);
        }
    }
}