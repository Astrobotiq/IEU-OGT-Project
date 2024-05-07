using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Harvest();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Plant();
        }
    }

    private void Harvest()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Vegetable"))
            {
                VegetableControl vegetableControl = hitCollider.GetComponent<VegetableControl>();
                if (vegetableControl != null && vegetableControl.isRipe)
                {
                    vegetableControl.isRipe = false;
                    _inventory.AddVegetable(hitCollider.gameObject);
                    
                    Destroy(hitCollider.gameObject);
                    
                    break; 
                }
            }
        }
    }

    private void Plant()
    {
        if (_inventory.count > 0)
        {
            Debug.Log("1");
            GameObject plantPrefab = _inventory.GetPlantPrefab(Inventory.VegetableType.Tomato);
            if (plantPrefab != null)
            {
                Debug.Log("2");

                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);
                foreach (var hitCollider in hitColliders)
                {
                    Debug.Log("3");

                    if (hitCollider.gameObject.CompareTag("Soil"))
                    {
                        Debug.Log("4");

                        SoilManager soilManager = hitCollider.gameObject.GetComponent<SoilManager>();
                        if (!soilManager.isPlanted)
                        {
                            Debug.Log("5");

                            GameObject plant = Instantiate(plantPrefab, hitCollider.transform.position, Quaternion.identity);
                            plant.SetActive(true);
                            soilManager.isPlanted = true;
                            _inventory.UseVegetable("Tomato");
                            break;
                        }
                    }
                }
            }
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
