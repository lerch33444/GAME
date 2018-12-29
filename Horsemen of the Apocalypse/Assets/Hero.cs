using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 3f, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D shit)
    {
        if (shit.gameObject.tag == "Enemy")
        {
            ReloadLevel();
        }
    }

}
