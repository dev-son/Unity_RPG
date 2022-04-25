using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 수학에서 물리에서 
// 1. 위치 벡터
// 2. 방향 벡터 
struct MyVector
{
    public float x;
    public float y;
    public float z;

    //         +
    //    +
    //+--------+
    // 방향의 전체크기
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    // 단위 벡터 : 크기가 1짜리인 벡터 , 크기가 1인 벡터는 크기는 무시한체 방향에 대한 벡터만 추출할 수 있다.
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } }

    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }



    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        //MyVector to = new MyVector(10.0f,0.0f, 0.0f);
        //MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        //// 목적지에서 내 자신을 빼야한다
        //MyVector dir = to - from; // (-5.0f, 0.0f, 0.0f)
        ////pos += new MyVector(0.0f, 2.0f, 0.0f);

        //// 방향이 나온다.
        //dir = dir.normalized; // (1.0f, 0.0f, 0.0f)

        //// from 이라는 점에서 우리가 원하는 방향으로 스피드 만큼을 이동을 한다.
        //MyVector newPos = from + dir * _speed;

        // 방향 벡터 
        // 1. 거리(크기) 5 magnitude
        // 2. 실제 방향 -> 우측

    }

    float _yAngle = 0.0f;
    void Update()
    {
        //transform.position += new Vector3(1.0f, 1.0f, 1.0f);
        /// =======================================================
        _yAngle += Time.deltaTime * _speed;

        // 절대 회전값 , 오일러 Vector3 타입이다.
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // + - delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

        // 오일러값을 쿼터니언으로
        //transform.rotation = Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));
        // Quaternion qt = transform.rotation;

        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward),0.5f);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.5f);

            transform.position += Vector3.back * Time.deltaTime * _speed;
            //transform.Translate(Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);

            transform.position += Vector3.left * Time.deltaTime * _speed;
            //transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);

            transform.position += Vector3.right * Time.deltaTime * _speed;
            //transform.Translate(Vector3.right * Time.deltaTime * _speed);
        }
        //transform.position.magnitude;   // 벡터의 크기
        //transform.position.normalized;  // 단위벡터 
    }
}
