using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	private GameGod _gg;
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private Transform _spawnTransform;

	public GameObject gunBubbles; //Particle effect to instantiate

	private void Start()
	{
		_gg = GameObject.FindGameObjectWithTag("GameGod").GetComponent<GameGod>();
	}

	private void Update()
	{
//		if (transform.parent.GetComponent<GunLookAtMouse> ().isPlayer2) {
//			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false) {
//				Shoot ();
//			}
//		} else {
//
//			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false) {
//				Shoot ();
//			}
//		}
	}

	public void Shoot(int playerID)
	{
		GameObject newBullet = Instantiate(_bulletPrefab, _spawnTransform.position, _spawnTransform.rotation) as GameObject;
		SimpleBulletController newBulletController = newBullet.GetComponent<SimpleBulletController>();
		newBulletController.controllerPos = transform.parent.GetComponent<GunLookAtMouse>().ControllerPos;
		newBulletController._bulletPlayerID = playerID;
		Instantiate(gunBubbles, _spawnTransform.position, _spawnTransform.rotation);
	}
}
