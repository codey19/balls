using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject falling;
    GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        int random = Random.Range(0, 22) - 11;
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(random, transform.position.y, Random.Range(0, 4) - 1);
            clone = Instantiate(falling, transform.position, transform.rotation);
            Destroy(clone, 1);
        }
    }

   
}
