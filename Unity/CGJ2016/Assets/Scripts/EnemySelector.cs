using System;
using System.Collections.Generic;
using UnityEngine;
using General.UnityMessages;

public class EnemySelector
{

    #region Variables
    GameObject left = null;
    GameObject right = null;
    GameObject target = null;

    OnTriggerEnterMessage LI = null;
    OnTriggerEnterMessage RI = null;
    OnTriggerExitMessage LO = null;
    OnTriggerExitMessage RO = null;

    bool isInLeft = false;
    bool isInRight = false;

    #endregion

    public EnemySelector(GameObject target)
    {
        this.target = target;
    }

    public void Init()
    {
        this.left = target.FindInChildren("left");
        this.right = target.FindInChildren("right");

        //this.LI = this.left.gameObject.GetBehaviour<OnTriggerEnterMessage>();
        //this.LI.action += LeftCollisionIn;
        //this.LO = this.left.gameObject.GetBehaviour<OnTriggerExitMessage>();
        //this.LO.action += LeftCollisionOut;
        //this.RI = this.right.gameObject.GetBehaviour<OnTriggerEnterMessage>();
        //this.RI.action += RightCollisionIn;
        //this.RO = this.right.gameObject.GetBehaviour<OnTriggerExitMessage>();
        //this.RO.action += RightCollisionOut;

#if UNITY_EDITOR
        giz = this.left.AddComponent<OnDrawGizmosMessage>();
        giz.action += draw;
#endif

        a = this.left.GetComponent<SphereCollider>();
        a.enabled = false;
        b = this.right.GetComponent<SphereCollider>();
        b.enabled = false;
    }

    OnDrawGizmosMessage giz = null;

    void LeftCollisionIn(Collider other)
    {
        this.isInLeft = true;
    }

    void LeftCollisionOut(Collider other)
    {
        this.isInLeft = false;
    }

    void RightCollisionIn(Collider other)
    {
        this.isInRight = true;
    }

    void RightCollisionOut(Collider other)
    {
        this.isInRight = false;
    }


    SphereCollider a = null;
    SphereCollider b = null;
    float radio = 10;
    void checksss()
    {
        Collider[] cols = null;


        cols = Physics.OverlapSphere(aPos(), radio);

        isInLeft = (cols.Length >= 1);

        //cols = Physics.OverlapSphere(bPos(), radio);

        //isInRight = (cols.Length >= 1);


    }

    public void draw()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aPos(), radio);
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(bPos(), 3);
    }

    Vector3 aPos()
    {
        return this.left.transform.TransformPoint(a.center);
    }



    Vector3 bPos()
    {
        return this.right.transform.TransformPoint(b.center);
    }

    public bool isMatcheable()
    {
        checksss();
        //return this.isInRight && this.isInLeft;
        return this.isInLeft;
    }
}


public class OnDrawGizmosMessage : MonoBehaviour
{
    public Action action;

    public void OnDrawGizmos()
    {
        action.Trigger();
    }
}