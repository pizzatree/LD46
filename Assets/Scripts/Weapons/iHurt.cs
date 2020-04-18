using UnityEngine;

public abstract class iHurt : MonoBehaviour
{
    [SerializeField]
    protected Allegiance allegiance = Allegiance.Friendly;
    protected float damage = 5f;

    private void Awake()
    {
        if(allegiance == Allegiance.Enemy)
         gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

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
