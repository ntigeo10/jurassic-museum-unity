using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }
    public abstract void onInteract();
    public abstract void stopInteract();
    public abstract void OnFocus();
    public abstract void onLoseFocus();


    

}
