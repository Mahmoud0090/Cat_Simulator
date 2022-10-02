using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHitter : MonoBehaviour
{
    public int explosionForce = 150;
    public int explosionRadius = 25;
    public GameObject[] hitParticles;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Hittable")
        {
            print("Ok");
            hit.gameObject.tag = "Hitted";
            Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
            obj_rb.isKinematic = false;
            obj_rb.AddExplosionForce(explosionForce, transform.position + Vector3.down, explosionRadius);
            Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.transform.position, Quaternion.identity);
        }
    }
}
