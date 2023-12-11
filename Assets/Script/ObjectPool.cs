using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public IPoolable prefab;
    public int initailCount = 20;
    private Queue<IPoolable> objectPool = new Queue<IPoolable>();




    void Awake()
    {
        for (int i = 0; i < initailCount; i++)
        {
            IPoolable prefabObject = Instantiate(prefab);
            prefabObject.SetupPool(this);
            objectPool.Enqueue(prefabObject);
            prefabObject.gameObject.SetActive(false);
        }
    }

    public IPoolable GetObject()
    {
        if (objectPool.Count > 0)
        {
            IPoolable obj = objectPool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            IPoolable obj = Instantiate(prefab);
            obj.SetupPool(this);
            return obj;
        }


    }



   

    public void RecyclePoolObject(IPoolable obj)
    {
       
        obj.gameObject.SetActive(false);
        objectPool.Enqueue(obj);

    }

   
}
