using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
    }

    public void TakeDamage()
    {
        health -= 10;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
