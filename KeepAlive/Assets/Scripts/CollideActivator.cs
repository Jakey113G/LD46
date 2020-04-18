using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This code is designed for 

public class CollideActivator : MonoBehaviour
{
    public string playerTagName = "Player";
    public bool canConsume = false;
    public bool canContinueToExist = true;

    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.Debug.Log("Collision Started");
        //UnityEngine.Debug.Log(KeyCode.F);  
    }

    // Update is called once per frame
    void Update()
    {
        if (canContinueToExist == false && canConsume == true)
        {
            Object.Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //UnityEngine.Debug.Log("Collision");
        if (other.tag == playerTagName && Input.GetAxis("Jump") > 0)
        {
            UnityEngine.Debug.Log("Trigger was Activated by "+playerTagName);
            //DO CODE HERE GUYS
            canContinueToExist = false;
        }
    }
}