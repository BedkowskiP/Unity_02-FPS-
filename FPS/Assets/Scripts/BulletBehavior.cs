using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("OnDisable", 12.0f);
    }

    private void OnDisable()
    {
        this.transform.gameObject.SetActive(false);
    }

}
