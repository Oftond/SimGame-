using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IVirus
{
    string Code { get; }
    float Infection {  get; }
    bool Reinfection { get; }
    float Lethality { get; }
    int AgeToInfect { get; }
    int DayToRecover { get; }

    void Infect(Person person);
    bool Death(Person person);
}