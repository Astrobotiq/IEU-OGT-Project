using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void WSAD(Vector2 dir)
    {
        rb.velocity = dir * speed;
    }

    public virtual void E()
    {
        //will do interactions
    }

    public virtual void MousePos(Vector2 pos) 
    {
        // will do hover things
    }

    public virtual void MouseLeft(Vector2 pos)
    {
        // will do select thing
    }


}
