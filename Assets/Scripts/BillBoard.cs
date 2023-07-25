using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam1;
    public Transform cam3;
    private void Update()
    {
        transform.LookAt(transform.position + cam1.forward);
        transform.LookAt(transform.position + cam3.forward);
    }
}
