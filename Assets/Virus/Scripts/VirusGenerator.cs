using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public GameObject VirusPrefab; // ���̷��� ������
    public float span = 0; // ���� ����
    public float delta = 0; // ��ŸŸ�� (����ȭ)
    
    public bool exist = false; // ���̷��� ���� ����

    void Start()
    {

        
    }

    void Update()
    {
        bool theEnd = CanvasControl.preProcessingEnd;

        var render = gameObject.GetComponents<Renderer>();

        foreach (var component in render)
            component.enabled = false;

        this.delta += Time.deltaTime;

        if (!theEnd)
        {
            this.delta = 0;
            this.exist = false;
        }

        if (span == 0)
        {
            this.span = Random.Range(3, 15);
        }

        if (this.delta > this.span && exist == false && theEnd)
        {
            GameObject instantVirus = Instantiate(VirusPrefab);
            instantVirus.transform.parent = gameObject.transform;
            instantVirus.transform.position = gameObject.transform.position;

            VirusController currentVirus = instantVirus.GetComponent<VirusController>();
            currentVirus.currentGen = gameObject.GetComponent<VirusGenerator>();
            

            this.span = Random.Range(1, 10);
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        *//*if (other.tag == "Virus")
        {
            this.exist = true;
            this.delta = 0;
        }*/
     /*   else
        {
                this.exist = false;
                this.delta = 0;
                Debug.Log("���̷����� �������.");
        }*//*
    }

*//*    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Virus")
        {
            this.exist = false;
            this.delta = 0;
            Debug.Log("���̷����� �������.");
        }
    }*/
}
