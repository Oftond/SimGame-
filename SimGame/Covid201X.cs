using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Covid201X : AVirus
{
    private static Random _random = new Random();

    public Covid201X(string code, bool reinfection, float infection, float lethality)
        : base(code, reinfection, infection, lethality)
    {
        _lethality = lethality + (float)_random.Next(-10, 10) / 100;
    }

    public override bool Death(Person person)
    {
        if (_random.NextDouble() <= Lethality)
            return true;
        return false;
    }

    public override void Infect(Person person)
    {
        if (person.Immunity <= Infection)
            person.Status = true;
    }
}