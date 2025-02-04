using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class Simulator
{
    private const double _mortaliity = (double)16 / 1000;
    private const double _birthrate = (double)8 / 1000;

    private static Random random = new Random();
    private List<Person> _alive;
    private List<Person> _dead;
    private int _maxDay;
    private int _day;

    public int MaxDays => _maxDay;

    public Simulator(int countPopulation, int maxDays)
    {
        _alive = new List<Person>();
        _dead = new List<Person>();
        _day = 0;
        _maxDay = maxDays;
        Population(countPopulation);
    }

    public void RunSimulation()
    {
        for (int i = 0; i < _maxDay; i++)
        {
            _day = i;
            foreach (Person person in _alive)
            {
                person.UpdateAge();
            }
            _alive.RemoveAll(p =>
            {
                if (p.Age >= 29200)
                {
                    _dead.Add(p);
                    return true;
                }
                return false;
            });
            _alive.RemoveRange(0, (int)_mortaliity);
            //Сделать смертность и рождаемость
        }
    }

    private void Population(int countPopulation)
    {
        for (int i = 0; i < countPopulation; i++)
        {
            Person person = new Person(random.Next(0, 2) == 0 ? "Ж" : "М", random.Next(0, 29201), 
                (float)random.Next(70, 76) / 100);
            if (person.Age >= 29200)
                _dead.Add(person);
            else
                _alive.Add(person);
        }
    }
}