using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterialAnim : MonoBehaviour
{
    public float ScrollX ;
    public float ScrollY ;
    private void Update()
    {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
