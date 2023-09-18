using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _defenseboost;
        private float _stamina;
        private Weapon _currentWeapon;



    public Character(string name, float health, float damage, float defense, float defenseboost, float stamina, Weapon currentWeapon)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _defenseboost = defenseboost;
            _stamina = stamina;
            _currentWeapon = currentWeapon;
        }

        public float GetDamage()
        {
            return _damage;
        }

    public float GetHealth()
        {
            return _health;
        }
    public Weapon GetWeapon()
        {
            return _currentWeapon;
        }

    public string GetName()
        {
            return _name;
        }

    public void RaiseDefense()
        {
            _defense += _defenseboost;
        }
        
    public void ResetDefense()
        {
            _defense -= _defenseboost;
        }





    public void PrintStats()
    {
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Health: " + _health);
        Console.WriteLine("Damage: " + _damage);
        Console.WriteLine("Defense: " + _defense);
        Console.WriteLine("Stamina: " + _stamina);
    }

    public void TakeDamage (float damage)
    {
        _health -= damage - _defense;
    }
    }

}
