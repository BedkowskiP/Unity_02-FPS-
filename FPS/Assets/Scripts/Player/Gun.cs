using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    public ParticleSystem particle;
    //public GameObject impactEffect;
    public PoolManager _pool;
    

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        particle.Play();
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            if(hit.collider.tag == "ObjectToDisplayHitHole")
            {
            Debug.Log(hit.transform.name);
            //Instantiate(bulletHole, hit.point + hit.normal * 0.0001f, Quaternion.FromToRotation(Vector3.up, hit.normal));
            for(int i = 0; i < _pool.bulletHoleList.Count; i++)
                {
                    if(_pool.bulletHoleList[i].activeInHierarchy == false)
                    {
                        _pool.bulletHoleList[i].SetActive(true);
                        _pool.bulletHoleList[i].transform.position = hit.point + hit.normal * 0.0001f;
                        _pool.bulletHoleList[i].transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        break;
                    }
                }
            }
        }

        //GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(impact, 2);

        
    }
}
