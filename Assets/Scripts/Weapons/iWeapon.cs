﻿using System;

public interface iWeapon
{
    void Fire();
    event Action OnFire;
    void Drop();
    void Equip();
}