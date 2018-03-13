using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLookAtMouse : MonoBehaviour 
{
	[SerializeField] private float _rotateSpeed;
	[SerializeField] private Transform _target;


	public int _playerID;
	public Vector3 ControllerPos = new Vector3(0,0,0);
	Vector3 previousControllerPos;
	void Start(){
		ControllerPos.x = Screen.width * 0.5f;
		ControllerPos.y = Screen.height * 0.5f;
	}

	void Update()
	{
//		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
//
//		Vector3 direction = (transform.position - mousePos).normalized;
//		Quaternion rotation = Quaternion.LookRotation(direction);
//		transform.rotation = rotation;
		if(_playerID == 1)
		{
			if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) 
			{
				ControllerPos = ControllerPos + new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0) * (Screen.width * 0.5f) * Time.deltaTime;
			}
		}
		else
		{
			if (Input.GetAxisRaw ("HorizontalPlayer2") != 0 || Input.GetAxisRaw ("VerticalPlayer2") != 0) 
			{
				ControllerPos = ControllerPos + new Vector3 (Input.GetAxisRaw ("HorizontalPlayer2"), Input.GetAxisRaw ("VerticalPlayer2"), 0) * (Screen.width * 0.5f) * Time.deltaTime;
			}
		}

		ControllerPos = new Vector3 (Mathf.Clamp (ControllerPos.x, 0, Screen.width), Mathf.Clamp (ControllerPos.y, 0, Screen.height), 0);

		Ray mouseRay = Camera.main.ScreenPointToRay(ControllerPos);
		float backingDis = (_target.position - Camera.main.transform.position).magnitude * 0.5f;
		transform.LookAt(mouseRay.origin + mouseRay.direction * backingDis);

		Debug.Log("Origin: " + mouseRay.origin);
	}
}
