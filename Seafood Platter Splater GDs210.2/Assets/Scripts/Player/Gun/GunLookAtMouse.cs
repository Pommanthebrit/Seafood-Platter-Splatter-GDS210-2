using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLookAtMouse : MonoBehaviour 
{
	[SerializeField] private float _rotateSpeed;
	[SerializeField] private Transform _target;


	void Update()
	{
//		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f);
//
//		Vector3 direction = (transform.position - mousePos).normalized;
//		Quaternion rotation = Quaternion.LookRotation(direction);
//		transform.rotation = rotation;

		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		float backingDis = (_target.position - Camera.main.transform.position).magnitude * 0.5f;
		transform.LookAt(mouseRay.origin + mouseRay.direction * backingDis);
	}
}
