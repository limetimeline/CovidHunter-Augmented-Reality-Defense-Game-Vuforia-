using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public float destroyTime = 1.0f;

    void Update()
    {
        Destroy(gameObject, destroyTime); // ����ũ�� destroyTime �� ����
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnTriggerEnter(Collider other)
    {
        /* ����ũ�� ����̳� ���� ������ �ı� */
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
