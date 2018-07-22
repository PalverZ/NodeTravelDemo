using System;
using UnityEngine;

public class TravelNode : MonoBehaviour
{
    public static event Action<TravelNode> OnNavigationInteract;

    public void FunctionToDoWhenImInteractedWith()
    {
        OnNavigationInteract(this);
    }


    //When object is clicked (Change this to what you need
    public void OnMouseDown()
    {
        FunctionToDoWhenImInteractedWith();
    }

}