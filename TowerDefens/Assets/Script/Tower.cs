using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Radius, FireDelay;
    public Transform BulletPrefab;
    public LayerMask EnemyLayer;
    

    private Transform enemy, gun, firePoin;
    private float timeToFire;
    void Start()
    {
        gun = transform.GetChild(0).GetChild(0);
        firePoin = gun.GetChild(0);
        timeToFire = FireDelay;
    }

   
    void Update()
    {
        if (timeToFire > 0)
            timeToFire -= Time.deltaTime;

        else if(enemy)
            Fire();

        if (enemy)
        {
            // слежка за  врага 
            Vector3 lookAt = enemy.position;
            lookAt.y = gun.position.y;
            gun.rotation = Quaternion.LookRotation(lookAt - gun.position);
            if (Vector3.Distance(transform.position, enemy.position) > Radius)
            {         
                enemy = null;
            }
            
        }
        else if (enemy == null)
        {
            Collider[] coll = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
            if (coll.Length > 0)
                enemy = coll[0].transform;
        }
       
    }
    private void Fire()
    {
        Transform bullet = Instantiate(BulletPrefab, firePoin.position, Quaternion.identity);
        bullet.LookAt(enemy.GetChild(0));

        timeToFire = FireDelay;

    }
}
