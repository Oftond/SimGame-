using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class AVirus : IVirus
{
    protected string _code;
    protected bool _reinfection;
    protected float _infection;
    protected float _lethality;

    protected AVirus(string code, bool reinfection, float infection, float lethality)
    {
        _code = code;
        _reinfection = reinfection;
        _infection = infection;
        _lethality = lethality;
    }

    public string Code => _code;

    public float Infection => _infection;

    public bool Reinfection => _reinfection;

    public float Lethality => _lethality;

    public abstract bool Death(Person person);

    public abstract void Infect(Person person);
}