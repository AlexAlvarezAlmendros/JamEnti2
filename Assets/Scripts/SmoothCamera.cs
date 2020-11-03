using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject nave;
    public GameObject newPos;
    //Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        //newPos = new Vector3(nave.transform.position.x, nave.transform.position.y +1, nave.transform.position.z - (5 * nave.GetComponent<Nave>().direction));
    }

    // Update is called once per frame
    void Update()
    {
        //newPos = new Vector3(nave.transform.position.x, nave.transform.position.y +1, nave.transform.position.z - (5 * nave.GetComponent<Nave>().direction));

        transform.position = Vector3.Lerp(transform.position, newPos.transform.position, 8 * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newPos.transform.eulerAngles, 1000 * Time.deltaTime);

    }
}
