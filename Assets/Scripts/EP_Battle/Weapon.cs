using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public Transform shotPoint;
   // public Animator camAnim;
    public Projectile Projectile;

    public bool inputAttack = false;
    


    private void Update()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);



        if (Input.GetKeyDown(KeyCode.Return)||inputAttack) {
            //camAnim.SetTrigger("shake");
            Projectile.filp = isFilp();

            Instantiate(projectile, shotPoint.position, transform.rotation);
            inputAttack = false;
        }
    }
        public bool isFilp(){
        if(GetComponent<SpriteRenderer>().flipX)
            return true;
        else return false;
    }
}
