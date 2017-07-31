using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    public float bulletSpeed = 30;

    public float lifeTime = 3;

	// Use this for initialization
	void Awake () 
    {
        // ignore player level
		Physics.IgnoreLayerCollision(7, 7, true);
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Fire();
        }
    }

    private void Fire() 
    {
        GameObject bullet = Instantiate(bulletPrefab);

        bullet.transform.position = bulletSpawn.position;

        var rot = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);

        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay) 
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
