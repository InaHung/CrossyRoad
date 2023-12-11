using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MoveObject
{
    
    public List<Transform> targetPositions = new List<Transform>();
    
   
    

    

    public Vector3 GetNearPosition(Vector3 playerPos)
    {
        Transform nearPoint = null;
        float minDistance = -1;
        for (int i = 0; i < targetPositions.Count; i++)
        {
            float distance = Vector3.Distance(playerPos, targetPositions[i].position);
            if (i == 0 || (i != 0 && distance < minDistance))
            {
                nearPoint = targetPositions[i];
                minDistance = distance;
            }
        }
        return nearPoint.position;
    }
}
