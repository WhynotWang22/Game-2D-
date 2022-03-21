using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bantruong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * 10f * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Enemy")
        {

            Destroy(col.gameObject);

            Destroy(gameObject);

        }
    }
}
