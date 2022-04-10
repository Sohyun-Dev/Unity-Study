using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public int playerSpeed = 1;

    public GameObject ball;
    public GameObject myHand;

    bool inHands = false;
    Vector3 ballPos;
    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;

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
            }
            else
            {
                ball.transform.SetParent(null);
                ball.transform.localPosition = ballPos;
                this.GetComponent<PlayerGrab>().enabled = false;
            }
            inHands = !inHands;

        }
    }
    
}
