using UnityEngine;
using System.Collections;

public enum CubeColor
{
	Blue,
	Green,
	Red,
	Yellow
}

public static class GameConfig
{
	public const int ColorCount = 4;
}

public class Cube : MonoBehaviour
{
	public CubeColor cubeColor = CubeColor.Blue;
	public int x = 0 ;
	public int y = 0 ;
	public int z = 0 ;
	public bool isFalling = false;

	void OnCollisionEnter(Collision collision) 
	{
		var oth = collision.collider.gameObject;
		BallScript curSc = oth.GetComponent<BallScript>();

		if(curSc != null && curSc.curColor == cubeColor)
		{
			Destroy(gameObject);
			
		}
		

	}


}
