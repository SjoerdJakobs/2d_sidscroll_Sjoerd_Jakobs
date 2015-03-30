using UnityEngine;
using System.Collections;

public class CamelBehaviour : MonoBehaviour {
	public float moveSpeed;
	private float countdown;
	private float dirY;
	// Use this for initialization
	void Start()
	{
        countdown = 1;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (transform.position.y <= 0f) {
			dirY = 1f;	
		} else if (transform.position.y >= 1f) {
			dirY = -1f;	
		}

		if (countdown > 0)
		{
			transform.Translate(new Vector2(1f,0f)* moveSpeed * Time.deltaTime);


			transform.Translate(new Vector2(0f,dirY)* moveSpeed * Time.deltaTime);
		}
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Wall1X")
        {
            moveSpeed = moveSpeed * -1;
        }
    }
}

