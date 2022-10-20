using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject aa;
    // Start is called before the first frame update
    void Create()
    {
        Instantiate(aa);
    }

     
}
