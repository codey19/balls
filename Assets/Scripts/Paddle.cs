using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public GameObject falling;
    public GameObject spawnPoint;
    //public Animation animate;
    public Text myText;
    public Text GameOver;
    GameObject glitter;
    public GameObject glitterPrefab;
    GameObject clone;
    int speed;
    int score;
    bool quit;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 3);
        score = 0;
        speed = 20;
        quit = false;
        //animate = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //if (quit)
        //    return;
        //float bound = 1.3f * transform.position.z + 14;
        float bound = 1.0f * transform.position.z + 10;

        if (Input.GetKey(KeyCode.D) && transform.position.x < bound){//9
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -bound){//-9
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.z < 13){//4
            transform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.z > -1 && transform.position.x < bound && transform.position.x > -bound)
        {//-1
            transform.position += Vector3.back * Time.deltaTime * speed;
        }

        if(score <=10)
            transform.localScale = new Vector3(transform.localScale.x, 0.05f + 0.01f * score, transform.localScale.z);
        
        /*if (score >= 1)
        {
            quit = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameOver = Instantiate(GameOver);
                GameOver.transform.SetParent(GameObject.Find("Canvas").transform, false);
            }


        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        //animate.Play();
        //if(!animate.isPlaying)
        Destroy(clone);//only works with one clone is the gamespace
        myText.text = "Score: "  + ++score;
        //myText.text = "apple";

    }

    public void Spawn() {
        if (quit)
            return;
        int random = UnityEngine.Random.Range(0, 20) - 10;
        spawnPoint.transform.position = new Vector3(random, spawnPoint.transform.position.y, UnityEngine.Random.Range(0, 12) - 1);
        clone = Instantiate(falling, spawnPoint.transform.position, spawnPoint.transform.rotation);
        glitter = Instantiate(glitterPrefab, spawnPoint.transform.position, glitterPrefab.transform.rotation);
        Destroy(glitter,5);
        Destroy(clone, 3);
       
    }
}
