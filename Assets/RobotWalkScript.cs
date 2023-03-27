using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWalkScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Direction", h);
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
    }
}
