using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycastDetection : MonoBehaviour
{
    [SerializeField] private GameObject raycastObject;
    [SerializeField] private float distance;

    private bool itemHeld;
    [SerializeField] private GameObject apple;


    private void Update()
    {
        CheckForHit();

        if(itemHeld == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            itemHeld = false;
            apple.SetActive(false);

        }
    }
    void CheckForHit()
    {

        RaycastHit objectHit;

        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * distance, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, distance) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //do something if hit object ie
            if (objectHit.collider.name == "Apple")
            {
                itemHeld = true;
                apple.SetActive(true);
            }
        }
    }
}
