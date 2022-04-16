using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;

    bool inHands = false;
    //Vector3 ballPos;

    Collider ballCol;
    Rigidbody ballRb;

    Camera cam;
    public float handPower;
    // Start is called before the first frame update
    void Start()
    {
        //ballPos = ball.transform.position;
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!inHands)
            {
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0, -0.6f, 0);
                ballCol.isTrigger = true;
                ballRb.useGravity = false;
                ballRb.velocity = Vector3.zero;

            }


            else
            {
                ball.transform.SetParent(null);
                //ball.transform.localPosition = ballPos;
                this.GetComponent<PlayerGrab>().enabled = false;
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;

            }

            inHands = !inHands;
        }
    }
}
