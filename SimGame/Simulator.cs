using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Simulator
{
    private const double _mortaliity = (double)14 / 1000;
    private const double _birthrate = (double)8 / 1000;

    private static Random random = new Random();

    private List<Person> _alive;
    private List<Person> _dead;
    private int _maxDay;
    private int _day;
    private AVirus _virus;

    public int Days => _day;

    public Simulator(int countPopulation, int maxDays, AVirus virus)
    {
        _alive = new List<Person>();
        _dead = new List<Person>();
        _day = 1;
        _maxDay = maxDays;
        _virus = virus;
        Population(countPopulation);
    }

    public void RunSimulation()
    {
        StartInfection();
        for (int i = 1; i < _maxDay; i++)
        {
            _day = i;
            if (i % 365 == 0)
                _alive.RemoveAll((p) =>
                {
                    p.UpdateAge();
                    if (p.Age >= p.MaxAge)
                    {
                        _dead.Add(p);
                        return true;
                    }
                    return false;
                });
            //_alive.Aggregate((p, p2) =>
            //{
            //    p.UpdateAge();
            //    return p2;
            //});
            Mortality();
            Birth();
        }
    }

    private void Mortality()
    {
        int mort = (int)Math.Round(_mortaliity * _alive.Count / 365);
        List<Person> toDead = _alive.GetRange(0, mort);
        _alive.RemoveRange(0, mort);
        _dead.AddRange(toDead);
    }

    private void Birth()
    {
        int birth = (int)Math.Round(_birthrate * _alive.Count / 365);
        for (int i = 0; i < birth; i++)
        {
            Person newPerson = new Person(random.Next(0, 2) == 0 ? "Ж" : "М", 0,
                (float)random.Next(70, 76) / 100);
            _alive.Add(newPerson);
        }
    }

    private void StartInfection()
    {
        int percentPeople = (int)Math.Round(_alive.Count * 0.02);
        for (int i = 0; i < percentPeople; i++)
        {
            _alive.Find((p) =>
            {
                if (p.Age > _virus.AgeToInfect && !p.Status)
                {
                    p.Status = true;
                    return true;
                }
                return false;
            });
        }
    }

    private void Infection()
    {

    }

    private void Population(int countPopulation)
    {
        for (int i = 0; i < countPopulation; i++)
        {
            Person person = new Person(random.Next(0, 2) == 0 ? "Ж" : "М", random.Next(0, 81),
                (float)random.Next(70, 76) / 100);
            if (person.Age >= person.MaxAge)
                _dead.Add(person);
            else
                _alive.Add(person);
        }
    }
}