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
        if (context.performed)
        {
            mousePos = context.ReadValue<Vector2>();
            input.MousePos(mousePos);
        }
        
    }

    public void onMouseLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(mousePos != null)
            {
                input.MouseLeft(mousePos);
            }
        }
    }

    public void onMouseRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            input.MouseRight(mousePos);
        }
    }

    public void onESC(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("ESC'ye basýldý");
            changeInputMovement(input.ESC());
        }
    }

    public void changeInputMovement(InputMovement inputMov)
    {
        input = inputMov;
        Debug.Log(input.name);
    }
}
