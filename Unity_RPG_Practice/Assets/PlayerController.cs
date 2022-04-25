using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���п��� �������� 
// 1. ��ġ ����
// 2. ���� ���� 
struct MyVector
{
    public float x;
    public float y;
    public float z;

    //         +
    //    +
    //+--------+
    // ������ ��üũ��
    public float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }
    // ���� ���� : ũ�Ⱑ 1¥���� ���� , ũ�Ⱑ 1�� ���ʹ� ũ��� ������ü ���⿡ ���� ���͸� ������ �� �ִ�.
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
        //// ���������� �� �ڽ��� �����Ѵ�
        //MyVector dir = to - from; // (-5.0f, 0.0f, 0.0f)
        ////pos += new MyVector(0.0f, 2.0f, 0.0f);

        //// ������ ���´�.
        //dir = dir.normalized; // (1.0f, 0.0f, 0.0f)

        //// from �̶�� ������ �츮�� ���ϴ� �������� ���ǵ� ��ŭ�� �̵��� �Ѵ�.
        //MyVector newPos = from + dir * _speed;

        // ���� ���� 
        // 1. �Ÿ�(ũ��) 5 magnitude
        // 2. ���� ���� -> ����

    }

    float _yAngle = 0.0f;
    void Update()
    {
        //transform.position += new Vector3(1.0f, 1.0f, 1.0f);
        /// =======================================================
        _yAngle += Time.deltaTime * _speed;

        // ���� ȸ���� , ���Ϸ� Vector3 Ÿ���̴�.
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // + - delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

        // ���Ϸ����� ���ʹϾ�����
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
        //transform.position.magnitude;   // ������ ũ��
        //transform.position.normalized;  // �������� 
    }
}
