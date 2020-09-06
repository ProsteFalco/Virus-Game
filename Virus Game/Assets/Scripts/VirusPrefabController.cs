using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusPrefabController : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(destroyVirusPrefab());
        Vector3 force = new Vector3(Random.Range(-3,3),Random.Range(1,5),0);
        rb.AddForce(force, ForceMode2D.Impulse);

    }


    void Update()
    {
        
    }

    IEnumerator destroyVirusPrefab()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
