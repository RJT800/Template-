using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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


    public Character()
        {
            _name = "";
            _health = 0f;
            _damage = 0f;
            _defense = 0f;
            _defenseboost = 0f;
            _stamina = 0f;
        }
    //construct (must be called when a character(in this case) is created to initialize its definition
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

    public string GetName()
        {
            return _name;
        }


        //calls for the damage of the attacker
        public float GetDamage()
        {
            return _damage;
        }

    public float GetHealth()
        {
            return _health;
        }

    public float GetDefense()
        {
            return _defense;
        }

    public float GetDefenseBoost()
        {
            return _defenseboost;
        }

    public float GetStamina()
        {
            return _stamina;
        }

    public Weapon GetCurrentWeapon()
        {
            return _currentWeapon;
        }
    public Weapon GetWeapon()
        {
            return _currentWeapon;
        }



    public void RaiseDefense()
        {
            _defense += _defenseboost;
        }
        
    public void ResetDefense()
        {
            _defense -= _defenseboost;
        }




    //must put virtual to have this function be able to be overidden;
    public virtual void PrintStats()
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
