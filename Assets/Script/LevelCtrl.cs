using UnityEngine;
using System.Collections;



public class LevelCtrl : MonoBehaviour {

	const int MAX_X = 9;
	const int MAX_Y = 9;
	const int MAX_Z = 9;

	public GameObject[,,] CubeMatrix = new GameObject[MAX_X,MAX_Y,MAX_Z];

	public GameObject[] CubePrefab;

	public GameObject[] BulletPrefab;

	// Use this for initialization
	void Start () {

		for(int x = 0 ; x < MAX_X; x ++)
		{
			for(int y = 0 ; y < MAX_Y; y++)
			{
				for(int z= 0 ; z < MAX_Z; z++)
				{
					int colorIndex = (MTRandom.GetRandomInt()) % 4;
					var curCube = (GameObject)Instantiate(CubePrefab[colorIndex]);
					curCube.transform.position = new Vector3(0.5f + x,0.5f+y,0.5f+z);
					CubeMatrix[x,y,z] = curCube;
					var cubeSc = curCube.GetComponent<Cube>();
					cubeSc.x = x;
					cubeSc.y = y;
					cubeSc.z = z;


				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
