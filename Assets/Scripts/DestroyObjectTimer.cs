using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectTimer : MonoBehaviour
{

    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
