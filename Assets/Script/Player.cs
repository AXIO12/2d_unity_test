using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    Rigidbody2D rb2d;

    public float flap = 500f;
    public float speed = 5;
    float direction = 0;

    public bool jump = false;

    static int channel = 0;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {


        if (Input.GetKey(KeyCode.RightArrow)){
            direction = 1.0f;
            Sound.PlaySe("walk",1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            direction = -1.0f;
            Sound.PlaySe("walk",1);
        } else{
            direction = 0.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Sound.PlaySe("ref",2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ParticleManager.StopParticle("key_aaa");
        }
        if (Input.GetKey(KeyCode.F))
        {
            ParticleManager.StopParticle("key_bbb");
        }

        rb2d.velocity = new Vector2(direction * speed,rb2d.velocity.y); 
         
        //ジャンプ
        if (Input.GetKey("space"))
        {
            if (!jump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x,0);
                rb2d.AddForce(Vector2.up * flap);
                jump = true;
                ParticleManager.PlayParticle("test", GetComponent<Transform>().position);
                ParticleManager.PlayParticle("aaa", "penguin","key_aaa");
                ParticleManager.PlayParticle("bbb","penguin","key_bbb");
                channel++;
                Sound.PlaySe("jump");
            }
        }
    }
}
