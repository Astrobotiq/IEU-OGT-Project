using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onWalk(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        
    }

    public void onE(InputAction.CallbackContext context)
    {

    }

    public void onMouse(InputAction.CallbackContext context)
    {
        var value =context.ReadValue<Vector2>();
    }

    public void onMouseLeft(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        Debug.Log(value);
    }
}
