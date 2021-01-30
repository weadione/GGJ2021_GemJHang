using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{

	// Start is called before the first frame update

	int speed = 10;
	void Update()
	{
		float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
		
		if (this.transform.position.x >= 0 && this.transform.position.x <= 34)
        {
			this.transform.Translate(new Vector3(xMove, 0, 0));  //이동
		}
		else if(this.transform.position.x < 0)
        {
			this.transform.position = new Vector3(0, 0, -10);
        }
		else if (this.transform.position.x > 34)
		{
			this.transform.position = new Vector3(34, 0, -10);
		}
	}

}
