using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	[SerializeField] private GameGod _gg;
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private Transform _spawnTransform;

	[Header("Audio Settings")]
	[SerializeField] private AudioClip _shootAudio;
	[SerializeField] private AudioClip _noAmmoAudio;

	private void Start()
	{
		_gg = GameObject.FindGameObjectWithTag("GameGod").GetComponent<GameGod>();
	}

	private void Update()
	{
		if (transform.parent.GetComponent<GunLookAtMouse> ().isPlayer2) {
			if (Input.GetButtonUp ("Fire2") && _gg._isPaused == false) {
				Shoot ();
			}
		} else {

			if (Input.GetButtonUp ("Fire1") && _gg._isPaused == false) {
				Shoot ();
			}
		}
	}

	private void Shoot()
	{
		if(_gg._currentAmmo > 0)
		{
			_gg._currentAmmo--;
			GameObject g =Instantiate(_bulletPrefab, _spawnTransform.position, _spawnTransform.rotation) as GameObject;
			g.GetComponent<SimpleBulletController> ().controllerPos = transform.parent.GetComponent<GunLookAtMouse> ().ControllerPos;
			_gg.PlayGlobal2DSound(_shootAudio);
		}
		else
		{
			_gg.PlayGlobal2DSound(_noAmmoAudio);
		}
	}
}
