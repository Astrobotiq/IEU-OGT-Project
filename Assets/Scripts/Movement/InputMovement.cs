using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    _Interactable interactable;
    _Hoverable hoverable;
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
        Vector2 worldPos = Camera.main.WorldToScreenPoint(pos);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(worldPos);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(Camera.main.transform.position,ray.direction,Color.red);
            if(hit.collider != null)
            {
                Debug.Log("Hittt colliderrr");
                Collider collider = hit.collider;
                if (collider.gameObject.GetComponent<_Hoverable>() != null)
                {
                    Debug.Log("Hoverable bulundu");
                    if(collider.gameObject.GetComponent<_Hoverable>() != hoverable)
                    {
                        hoverable.onHoverEnd();
                        hoverable = collider.gameObject.GetComponent<_Hoverable>();
                        hoverable.onHover();
                    }

                }
                else if (collider.gameObject.GetComponent<_Hoverable>()==null && hoverable != null)
                {
                    hoverable.onHoverEnd();
                    hoverable = null;
                }
            }
        }
    }

    public virtual void MouseLeft(Vector2 pos)
    {
        // will do select thing
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<_Interactable>() != null)
        {
            interactable = collision.gameObject.GetComponent<_Interactable>();
        }
    }

    


}
