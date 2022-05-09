using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour
{
    public int Speed;
    public float x_range;  //0~2.5
    Vector3 pos;
    float r_limit;
    float l_limit;
    bool is_right = true;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
        x_range = 2f;
        r_limit = pos.x + x_range;
        l_limit = pos.x;

        this.gameObject.transform.rotation = Quaternion.Euler(0,0,45);
    }

    void Update()
    {
        moveControl();
        //moveRight();

    }

    void moveControl()
    {
        float distanceY = Speed * Time.deltaTime;

        if(this.gameObject.transform.position.x > r_limit)
        {
            is_right = false;
            finger_Rotate(is_right);
        }
        if(this.gameObject.transform.position.x < l_limit)
        {
            is_right = true;
            finger_Rotate(is_right);
            //Debug.Log("right로 바뀜");
        }


        this.gameObject.transform.Translate(0, -1 * distanceY, 0);

    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void finger_Rotate(bool is_right)
    {
        if(is_right == true)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,45);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,-45);
            //this.gameObject.transform.Rotate(new Vector3(0,0,))
        }

    }



}
