using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelScript : MonoBehaviour
{

    public GameObject Jewel;
    public Vector3[] Locs;
    int random(int min ,int max)
    {
        return Mathf.FloorToInt(Random.Range(min, max));
    }

    void Awake()
    {
        int i = random(0, 4);
        Instantiate(Jewel, new Vector3(Locs[i].x, Locs[i].y, Locs[i].z), Quaternion.identity);
    }
}
