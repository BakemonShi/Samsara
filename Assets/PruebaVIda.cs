using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaVIda : MonoBehaviour

    
{

    public float lifeEnemy=3;

    void Update()
    {
        if(lifeEnemy == 0)
        {
            Destroy(this.gameObject);
        }
        
    }


}
