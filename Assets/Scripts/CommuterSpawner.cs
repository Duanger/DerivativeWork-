using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommuterSpawner : MonoBehaviour
{
	public int SpawnInstanceBreakDuration;
	public GameObject CommuterPrefab;
	public Transform spawnLocation;

	private bool leftRunOnce;
	private bool rightRunOnce;
	private playerLook playLook;
	void Start ()
	{
		playLook = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerLook>();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (playLook.LeftSpawnerHit && !leftRunOnce)
		{
			StartCoroutine(InstantiatePrefabs(leftRunOnce,SpawnInstanceBreakDuration));
		}

		if (playLook.RightSpawnerHit && !rightRunOnce)
		{
			StartCoroutine(InstantiatePrefabs(rightRunOnce, SpawnInstanceBreakDuration));
		}
	}

	IEnumerator InstantiatePrefabs(bool spawnerRunOnce, int seconds)
	{
		spawnerRunOnce = true;
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return null;
			yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Instantiate(CommuterPrefab, spawnLocation.position, Quaternion.identity);
			StopCoroutine(InstantiatePrefabs(spawnerRunOnce,seconds));
	}
}
