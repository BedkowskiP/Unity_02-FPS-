using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject bulletHolePrefab;

    public List<GameObject> bulletHoleList;

    public int spawnCount = 200;

    void Start()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            GameObject bullet = Instantiate(bulletHolePrefab);          
            bulletHoleList.Add(bullet);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
        }
    }
}
