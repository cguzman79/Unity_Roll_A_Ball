using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	private Rigidbody rb;
	public Text countText;
	public Text winText;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Red Pickup"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		else if (other.gameObject.CompareTag ("Green Pickup"))
		{
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}
		else if (other.gameObject.CompareTag ("Gold Pickup"))
		{
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText ();
		}
		else if (other.gameObject.CompareTag ("Special Pickup"))
		{
			other.gameObject.SetActive (false);
			count = count + 12;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Total Score: " + count.ToString ();
		if (count >= 100)
		{
			winText.text = "You Win!";
		}
	}


}
