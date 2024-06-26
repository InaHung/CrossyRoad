using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPoolable : MonoBehaviour
{
    public ObjectPool myPool;

    public void SetupPool(ObjectPool vehiclePool)
    {
        myPool = vehiclePool;
    }

    public virtual void Dispose()
    {

        myPool.RecyclePoolObject(this);
    }
}
