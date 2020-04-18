using UnityEngine;

public abstract class iHurt : MonoBehaviour
{
    protected Allegiance allegiance = Allegiance.Friendly;
    protected float damage = 5f;
    protected float speed = 5f;
}

public enum Allegiance
{
    Friendly,
    Enemy
}
