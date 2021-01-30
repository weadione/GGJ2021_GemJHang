using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotobattle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int bsn = Random.Range(0, 4);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform)
            {
                switch (bsn)
                {
                    case 0:
                        SceneManager.LoadScene("BS_004");
                        break;
                    case 1:
                        SceneManager.LoadScene("BS_005");
                        break;
                    case 2:
                        SceneManager.LoadScene("BS_101");
                        break;
                    case 3:
                        SceneManager.LoadScene("BS_102");
                        break;
                }

            }
        }
    }
}
