using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Simulator
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

            //_alive.ForEach(p =>
            //{
            //    p.UpdateAge();
            //    if (p.Age >= 29200)
            //    {
            //        _alive.Remove(p);
            //        _dead.Add(p);
            //    }
            //});

            _alive.RemoveAll((p) => UpdatePop(p));
            Console.WriteLine(i);

            //for (int k = 0; k < (int)Math.Round(_alive.Count * _mortaliity); k++)
            //{
            //    if (_alive.Count >= (int)Math.Round(_alive.Count * _mortaliity))
            //    {
            //        _alive.Add(_alive[k]);
            //        _alive.RemoveAt(k);
            //    }
            //}

            //for (int j = 0; j < (int)Math.Round(_alive.Count * _birthrate); j++)
            //{
            //    Person person = new Person(random.Next(0, 2) == 0 ? "Ж" : "М", random.Next(0, 29201), 
            //        (float)random.Next(70, 76) / 100);
            //    _alive.Add(person);
            //    person = null;
            //}
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

    private bool UpdatePop(Person p)
    {
        p.UpdateAge();
        if (p.Age >= 29200)
        {
            _dead.Add(p);
            return true;
        }
        return false;
    }
}