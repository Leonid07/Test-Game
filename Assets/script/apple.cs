using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    //Разделение яблока на дольки и падение его по гравитации
    public GameObject part1, part2;
    Rigidbody rigidbody1;
    Rigidbody rigidbody2;
    void Start()
    {
        rigidbody1 = part1.GetComponent<Rigidbody>();
        rigidbody2 = part2.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().useGravity == true)
        {
            rigidbody1.isKinematic = false;
            rigidbody1.useGravity = true;
            rigidbody2.isKinematic = false;
            rigidbody2.useGravity = true;
        }
        if (GameObject.Find("log").GetComponent<RotationLog>().hp_log <= 0)
        {
            gameObject.GetComponent<SphereCollider>().isTrigger = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Если нож попал по яблоку
        if (other.tag == "knife")
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("Camera").GetComponent<DropKnife>().Apple++;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.parent = GameObject.Find("KnifeTransform").transform;
        }
    }
}
