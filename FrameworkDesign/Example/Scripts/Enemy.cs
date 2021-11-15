using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FrameworkDesign.Example
{
    public class Enemy : MonoBehaviour
    {
        private static int mKilledEnemyCount = 0;

        private void OnMouseDown()
        {
            Destroy(gameObject);
            mKilledEnemyCount++;

            if (mKilledEnemyCount == 10)
                GamePassEvent.Trigger();
                
        }
    }   
}


