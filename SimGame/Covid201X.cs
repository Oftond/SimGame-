using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Covid201X : AVirus
{
    public Covid201X(string code, bool reinfection, float infection, float lethality)
        : base(code, reinfection, infection, lethality) { }

    public override bool Death(Person person)
    {
        Random random = new Random();
        if (random.NextDouble() <= Lethality)
            return true;
        return false;
    }

    public override void Infect(Person person)
    {
        Random random = new Random();
        if (random.NextDouble() + person.Immunity <= Infection)
        {
            person.Status = true;
        }
    }
}