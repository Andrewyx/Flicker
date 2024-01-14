using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArray2D : MonoBehaviour
{
    // Start is called before the first frame update
    public int[,] lightMap = new int[,] {
        {0, 0, 0, 0, 0, 0, 0}, 
        {0, 0, 1, 0, 1, 1, 1}, 
        {0, 0, 0, 0, 0, 0, 0}, 
        {0, 0, 1, 0, 1, 1, 1}, 
        {0, 0, 1, 0, 1, 1, 1}, 
        {0, 0, 1, 0, 1, 1, 1},
        {0, 0, 0, 0, 0, 0, 0}        
    };
}
