using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Grabbable
{
  
    [SerializeField]
    private Transform holder;
    
    [SerializeField]
    private bool isGrabbed = false;
    
    [SerializeField]
    private GameObject player;

    void Start(){
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact() {
        if (isGrabbed) {
            Release();
        } else {
            Grab();
        }
    }

    protected override void Grab() {
        isGrabbed = true;
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        this.GetComponent<Rigidbody2D>().isKinematic = true;    
        player.layer = 7;
    }

    protected override void Release() {
        isGrabbed = false;
        transform.SetParent(null);
        this.GetComponent<Rigidbody2D>().isKinematic = false;   
        player.layer = 0;
    }



}
