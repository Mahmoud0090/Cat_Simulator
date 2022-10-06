using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatHitter : MonoBehaviour
{
    public GameObject textScore;
    public TextMesh textScore3D;
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
            HittableObject ho = hit.gameObject.GetComponent<HittableObject>();
            HitEffect(hit, obj_rb);
            Score3DEffect(ho);
            GetCoins(ho);
        }
    }

    private void Score3DEffect(HittableObject ho)
    {
        int newScore = int.Parse(textScore.GetComponent<TextMeshProUGUI>().text) + ho.points;
        textScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
        textScore3D.text = "+" + ho.points;
        Invoke("ResetText3D", 0.5f);
    }

    private void HitEffect(ControllerColliderHit hit, Rigidbody obj_rb)
    {
        obj_rb.isKinematic = false;
        obj_rb.AddExplosionForce(explosionForce, transform.position + Vector3.down, explosionRadius);
        Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.transform.position, Quaternion.identity);
    }

    public void ResetText3D()
    {
        textScore3D.text = "";
    }

    public void GetCoins(HittableObject ho)
    {
        int actualCoins = PlayerPrefs.GetInt("nbCoins", 0);
        PlayerPrefs.SetInt("nbCoins", actualCoins + ho.coins);
    }
}
