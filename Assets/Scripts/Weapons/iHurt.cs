using UnityEngine;

public abstract class iHurt : MonoBehaviour
{
    protected Allegiance allegiance = Allegiance.Friendly;
    protected float damage = 5f;

    protected bool ValidHit(string name)
    {
        if (allegiance == Allegiance.Friendly && name == "Player")
            return false;
        return true;
    }
}

public enum Allegiance
{
    Friendly,
    Enemy
}
