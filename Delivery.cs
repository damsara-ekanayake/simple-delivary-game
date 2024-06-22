using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    int packageCount = 0;
    [SerializeField] float destroyTime;
    [SerializeField] int pickUpCount;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && packageCount < pickUpCount)
        {
            //Debug.Log("Picked up the package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            packageCount++;
            Destroy(collision.gameObject, destroyTime);
            //Debug.Log(packageCount);
        }

        if(collision.tag == "Customer" && hasPackage)
        {
            //Debug.Log("Delivered the package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            packageCount = 0;
            //Debug.Log(packageCount);
        }

    }
}
