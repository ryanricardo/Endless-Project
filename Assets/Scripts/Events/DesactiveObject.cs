using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveObject : MonoBehaviour
{
    public GameObject obj;

    public void FunctionDesactiveObject()
    {
        obj.gameObject.SetActive(false);
    }
}
