using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	[SerializeField] private GameGod _gg;
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private Transform _spawnTransform;

	public GameObject gunBubbles; //Particle effect to instantiate

	[Header("Audio Settings")]
	[SerializeField] private AudioClip _shootAudio;
	[SerializeField] private AudioClip _noAmmoAudio;

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

	public void Shoot()
	{
		GameObject newBullet = Instantiate(_bulletPrefab, _spawnTransform.position, _spawnTransform.rotation) as GameObject;
		newBullet.GetComponent<SimpleBulletController>().controllerPos = transform.parent.GetComponent<GunLookAtMouse>().ControllerPos;
		_gg.PlayGlobal2DSound(_shootAudio);
		GameObject gunBubble = Instantiate(gunBubbles, _spawnTransform.position, _spawnTransform.rotation) as GameObject;
//		else
//		{
//			_gg.PlayGlobal2DSound(_noAmmoAudio);
//		}
	}
}
