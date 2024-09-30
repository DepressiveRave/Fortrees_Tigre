using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool IsDrag = false; 
    public bool SetIsDrag;

    private void Awake()
    {
        IsDrag = SetIsDrag;
        Debug.Log(IsDrag);
    }
}
