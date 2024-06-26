using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    _Interactable interactable;
    _Hoverable hoverable;
    private Camera mainCamera;
    [SerializeField]
    public InputMovement otherManager;
    public WandSO leftClick;
    public WandSO rightClick;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        speed = 2f;
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
        if (interactable != null)
        {
            interactable.onInteract();
        }
        else
        {
            Debug.Log("There is nothing to interact");
        }
    }

    public virtual void MousePos(Vector2 pos) 
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(pos));
        
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<_Hoverable>() != null)
            {
                if(hoverable != null)
                {
                    if(hit.collider.GetComponent<_Hoverable>() != hoverable)
                    {
                        hoverable.onHoverEnd();
                        hoverable = hit.collider.GetComponent<_Hoverable>();
                        hoverable.onHover();
                    }
                }
                else if (hoverable == null)
                {
                    hoverable = hit.collider.GetComponent<_Hoverable>();
                    hoverable.onHover();
                }
            }
            else if (hit.collider.gameObject.GetComponent<_Hoverable>() == null)
            {
                if(hoverable != null)
                {
                    hoverable.onHoverEnd();
                    hoverable = null;
                }
            }
        }
        

    }

    public virtual void MouseLeft(Vector2 pos)
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(pos);
        Debug.Log(mousePos);
        if(leftClick != null)
        {
            Debug.Log("scriptable object burada");
            leftClick.onUse(transform.position, mousePos);
        }
        else if(leftClick == null)
        {
            Debug.Log("scriptable object burada de�il");
        }
    }

    public virtual void MouseRight(Vector2 pos)
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(pos);
        Debug.Log(mousePos);
        if (rightClick != null)
        {
            Debug.Log("scriptable object burada");
            rightClick.onUse(transform.position, mousePos);
        }
        else if (rightClick == null)
        {
            Debug.Log("scriptable object burada de�il");
        }
    }

    public virtual InputMovement ESC()
    {
        //Open UI and change InputMovement to InputUI
        return otherManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<_Interactable>() != null)
        {
            interactable = collision.gameObject.GetComponent<_Interactable>();
        }
    }

    


}
