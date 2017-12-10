﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRobot : Robot {
   
    public Transform takeblePoint;
    private Takeble currentTarget = null;
    private bool isTook = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ExtraSkill()
    {
        base.ExtraSkill();

        if (currentTarget == null) return;

        if (!isTook)
        {
            currentTarget.Take(takeblePoint);
        }
        else
        {
            currentTarget.Drop();
        }

        isTook = !isTook;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!isTook && collision.gameObject.CompareTag("Takeble"))
        {
            currentTarget = collision.gameObject.GetComponent<Takeble>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isTook && collision.gameObject.CompareTag("Takeble"))
        {
            currentTarget = null;
        }
    }
}