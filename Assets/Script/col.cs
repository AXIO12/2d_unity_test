using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour {
    private Player player;
	// Use this for initialization
	void Start () {
        player = GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.jump = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
            player.jump = false;
        
    }
}
