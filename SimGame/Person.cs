using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private const float _coefLostImmunity = 0.000017f;

    private string _gender;
    private int _age;
    private float _initialImmunity;
    private float _immunity;
    private bool _totalImmunity;
    private bool _isAlive;
    private int _friends;
    private int _infectionDays;
    private bool _status;

    public int Age => _age;
    public int MaxAge => 80;
    public string Gender => _gender;
    public float Immunity => _immunity;
    public bool TotalImmunity => _totalImmunity;
    public int Friends => _friends;
    public bool IsAlive => _isAlive;
    public bool Status => _status;

    public Person(string gender, int age, float immunity)
    {
        _gender = gender;
        _age = age;
        _immunity = immunity;
        _initialImmunity = immunity;
        _totalImmunity = false;
        _isAlive = true;
        _friends = (int)Gaussian.RandNormal(3, 1);
        _infectionDays = 0;

        _status = false;
        UpdateImmunity();
    }

    public int UpdateInfection()
    {
        if (!Status) _infectionDays = 0;
        else _infectionDays++;
        return _infectionDays;
    }

    public void UpdateAge()
    {
        _age++;
        if (_age >= MaxAge)
            Death();
        UpdateImmunity();
    }

    public void Death() => _isAlive = false;

    public void Infect() => _status = true;

    public void Recover() => _status = false;

    public void CreateTotalImmunity() => _totalImmunity = true;

    private void UpdateImmunity()
    {
        if (!IsAlive)
            return;
        _immunity = _initialImmunity - _coefLostImmunity * _age * 365;
    }
}