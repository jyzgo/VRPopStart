using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	public GameObject[] projectiles;

	public Transform CameraTrans;

	public float shotForce = 1000f;
	public float moveSpeed = 10f;


	public GameObject curProject = null;
	public void ReloadProject()
	{
		if(curProject == null)
		{
			var colorIndex = MTRandom.GetRandomInt() % GameConfig.ColorCount;
			curProject = Instantiate<GameObject>(projectiles[colorIndex]);
			var sc = curProject.GetComponent<BallScript>();
			sc.curColor = (CubeColor)colorIndex;

			curProject.transform.SetParent(CameraTrans,false);
			curProject.transform.localPosition = new Vector3(0,-0.4f,0.8f);

		}
	}

	void Start()
	{
		ReloadProject()	;
	}


	void Update ()
	{

		if(Input.GetButtonUp("Fire1"))
		{
			if(curProject !=null)
			{
				var curRigid = curProject.AddComponent<Rigidbody>();
				curRigid.AddForce(CameraTrans.forward * 800 );
				curProject.transform.SetParent(null,true);
				Destroy(curProject,5f);
				curProject = null;
				StartCoroutine(DelayReload());
			}

		}
	}

	IEnumerator DelayReload()
	{
		yield return new WaitForSeconds(0.35f);
		ReloadProject();

	}





}