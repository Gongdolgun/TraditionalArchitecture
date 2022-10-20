using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int NextState;
    
    
    private void OnMouseUp()
    {
        Debug.Log(this.name);
        //SendMessageUpwards("SetState", NextState);
    }
}
