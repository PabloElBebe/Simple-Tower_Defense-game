using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWalking
{
    public IEnumerator GoByThePath(List<Transform> path, float speedMult);
}
