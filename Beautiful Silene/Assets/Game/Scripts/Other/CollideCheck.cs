using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCheck : MonoBehaviour
{
    [SerializeField] Transform checkPosition;
    [SerializeField] LayerMask checkLayer;    
    [SerializeField] float checkRadius;
    public bool InContact;


    void Update()
    {
        bool IsGrounded = Physics.CheckSphere(checkPosition.position, checkRadius, checkLayer);
        if (IsGrounded == true)
        {
            InContact = true;
        }
        else
        {
            InContact = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPosition.transform.position, checkRadius);
    }
}
