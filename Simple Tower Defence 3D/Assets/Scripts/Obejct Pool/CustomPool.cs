using System.Collections.Generic;
using UnityEngine;

public abstract class CustomPool<T> where T : MonoBehaviour
{
    protected List<T> Objects;

    public abstract T Get();
    public abstract void Release(GameObject obj);
    public abstract T Create();
}
