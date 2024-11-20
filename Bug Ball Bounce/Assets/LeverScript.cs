using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private bool switched;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Lever Activated");
        if(!switched && collision.gameObject.CompareTag("Ball"))
        {
            obj.SetActive(false);
            gameObject.transform.Rotate(new Vector3(0, 0, -60));
            switched = true;
        }
    }
}
