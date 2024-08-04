using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TagSystem : MonoBehaviour
{

    public CircleCollider2D tagCollider;

    public bool areYouIt;
    public bool checkWhosIt;
    // Start is called before the first frame update
    void Start()
    {
        checkWhosIt = false;
        StartCoroutine(WhosItCheck());
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkWhosIt)
        {
            return;
        }
        if (areYouIt)
        {
            tag = "It";
        }
        else
        {
            tag = "Runner";
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "It")
        {
            if (collision.tag == "Runner")
            {
                areYouIt = false;
            }
        }

        if (tag == "Runner")
        {
            if (collision.tag == "It")
            {
                areYouIt = true;
                if (areYouIt)
                {
                    transform.position = GameObject.FindGameObjectWithTag("HomeBase").transform.position;
                }
            }
        }
    }

    IEnumerator WhosItCheck()
    {
        yield return new WaitForSeconds(.1f);

        if (tag == "It")
        {
            areYouIt = true;
        }
        else
        {
            areYouIt = false;
        }

        checkWhosIt = true;
    }
}
