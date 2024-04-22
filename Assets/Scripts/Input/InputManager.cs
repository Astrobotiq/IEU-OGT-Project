using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Vector2 mousePos;
    [SerializeField]
    InputMovement input;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onWSAD(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        input.WSAD(value);
        Debug.Log(value);
    }

    public void onE(InputAction.CallbackContext context)
    {
        input.E();
    }

    public void onMouse(InputAction.CallbackContext context)
    {

        mousePos =context.ReadValue<Vector2>();
        input.MousePos(mousePos);
    }

    public void onMouseLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(mousePos != null)
            {
                Debug.Log(mousePos);
                input.MouseLeft(mousePos);
            }
        }
    }
}
