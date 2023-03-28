using System;

public abstract class Creature
{
    private string _name;
    private int _currentHp, _maxHp;
    private int _stamina, _currentStamina, _mana, _currentMana, _damage;
    protected int _armor;

    public Creature(string name, int hp, int stamina, int mana, int armor)
    {
        _name = name;
        _currentHp = hp;
        _maxHp = hp;
        _stamina = stamina;
        _currentStamina = stamina;
        _mana = mana;
        _currentMana = mana;
        _armor = armor;
    }

    public abstract int Attack();
    public abstract void Exert();
    public abstract void Die();

    public void TakeDamage(int damageAmount)
    {
        _currentHp -= damageAmount;
    }
    public void UseStamina(int amount)
    {

    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }


    public string GetHP()
    {
        return _currentHp.ToString();
    }
    public string GetStamina()
    {
        return _stamina.ToString();
    }
    public string GetMana()
    {
        return _mana.ToString();
    }


}