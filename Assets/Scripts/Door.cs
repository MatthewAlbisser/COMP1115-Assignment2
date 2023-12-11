using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool inRange;
    public Key key;

    void Update()
    {
        if (inRange)
        {
            if (key.hasKey)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenDoor();
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}