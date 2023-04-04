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


    public abstract void Attack(Room room);
    public abstract void Exert();
    public abstract void Die();

    public void TakeDamage(int damageAmount)
    {
        _currentHp -= damageAmount;
        if (_currentHp <= 0)
        {
            _currentHp = 0;
        }
    }
    public void UseStamina(int amount)
    {
        _stamina -= amount;
        if (_stamina <= 0)
        {
            _stamina = 0;
        }
    }
    public void UseMana(int amount)
    {
        _mana -= amount;
        if (_mana <= 0)
        {
            _mana = 0;
        }
    }

    public void SetDamage(int newDamage)
    {
        _damage = newDamage;
    }
    public int GetDamage()
    {
        return _damage;
    }

    public int GetHP()
    {
        return _currentHp;
    }
    public int GetStamina()
    {
        return _currentStamina;
    }
    public int GetMana()
    {
        return _currentMana;
    }

    public string Display()
    {
        return ($"{_name}: HP:{_currentHp}");
    }

    public int GetArmor()
    {
        return _armor;
    }
    public void SetArmor(int amount)
    {
        _armor = amount;
    }

    public void Heal(int amount)
    {
        _currentHp += amount;
        if (_currentHp >= _maxHp)
        {
            _currentHp = _maxHp;
        }
    }
    public void RecoverMana(int amount)
    {
        _currentMana += amount;
        if (_currentMana >= _mana)
        {
            _currentMana = _mana;
        }
    }
    public void RecoverStamina(int amount)
    {
        _currentStamina += amount;
        if (_currentStamina >= _stamina)
        {
            _currentStamina = _stamina;
        }
    }
}