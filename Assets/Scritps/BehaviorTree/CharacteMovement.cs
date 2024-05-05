using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteMovement : MonoBehaviour
{
    private float speed = 5f;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y)*Time.deltaTime*speed;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
