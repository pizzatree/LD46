using System;

public interface iWeapon
{
    void Fire();
    event Action OnFire;
    void ReplenishAmmo();
    void Drop();
    void Equip();
}