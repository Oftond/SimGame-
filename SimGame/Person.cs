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

    public int Age => _age;
    public string Gender => _gender;
    public float Immunity => _immunity;
    public bool TotalImmunity => _totalImmunity;
    public bool IsAlive => _isAlive;
    public bool Status {  get; set; }

    public Person(string gender, int age, float immunity)
    {
        _gender = gender;
        _age = age;
        _immunity = immunity;
        _initialImmunity = immunity;
        _totalImmunity = false;
        _isAlive = true;

        Status = false;
        UpdateImmunity();
    }

    private void UpdateAge()
    {
        _age++;
        if (_age >= 29200)
            _isAlive = true;
        UpdateImmunity();
    }

    public void Detach() => _isAlive = false;

    public void CreateTotalImmunity()
    {
        _totalImmunity = true;
    }

    private void UpdateImmunity()
    {
        if (!IsAlive)
            return;
        _immunity = _initialImmunity - _coefLostImmunity * _age;
    }
}