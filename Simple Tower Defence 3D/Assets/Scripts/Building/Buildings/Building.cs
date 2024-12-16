using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public int Price;

    protected bool IsPlaced;

    public void Init(int price)
    {
        Price = price;
    }
    
    public void Place()
    {
        IsPlaced = true;
    }
}
