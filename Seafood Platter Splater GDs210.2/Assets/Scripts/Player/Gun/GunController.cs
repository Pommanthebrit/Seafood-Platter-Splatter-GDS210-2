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
		if(Input.GetButtonUp("Fire1"))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		if(_gg._currentAmmo > 0)
		{
			_gg._currentAmmo--;
			Instantiate(_bulletPrefab, _spawnTransform.position, _spawnTransform.rotation);
			_gg.PlayGlobal2DSound(_shootAudio);
		}
		else
		{
			_gg.PlayGlobal2DSound(_noAmmoAudio);
		}
	}
}
