using UnityEngine;

public abstract class Building : MonoBehaviour
{
    protected float Price;

    protected bool IsPlaced;

    public void Place()
    {
        IsPlaced = true;
    }
}
