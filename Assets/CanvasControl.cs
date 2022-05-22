using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class CanvasControl : MonoBehaviour
{
    public GameObject leftHands;
    public GameObject rightHands;
    public GameObject cycleGuideViews;
    public GameObject crossHair;
    public GameObject countDown;
    public GameObject videoPlayer;

    public GameObject virusPoint1;
    public GameObject virusPoint2;
    public GameObject virusPoint3;
    public GameObject virusPoint4;
    public GameObject virusPoint5;
    public GameObject virusPoint6;
    public GameObject virusPoint7;
    public GameObject virusPoint8;

    public Text countDownText;

    public VideoPlayer video;

    bool videoEnd = true; // ������ �߰� �Ϸ��� false�� �ٲٸ� ��
    bool countEnd = false;
    bool realEnd = false;

    static public bool preProcessingEnd = false;


    public int count;

    // Start is called before the first frame update
    void Start()
    {
        video.loopPointReached += CheckOver;
    }


    /* ������ ������ �� */
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Is Over");
        videoEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool Ts = DefaultObserverEventHandler.TrackingSuccess;

        if (Ts) // �νĿ� �������� ��
        {

            if (!videoEnd) // �ν��� �����ϰ� ���� 1ȸ
            {
                videoPlayer.SetActive(true); // ������ �÷��̾� ������
                video.Play(); // ������ ���
            }
            else // �������� �� ���� ���� videoEnd�� true�� ���
            {
                if (!countEnd && !realEnd) // �ν� ���� �� ������ �ٺ��� ī��Ʈ ���� 1ȸ
                {
                    videoPlayer.SetActive(false); // ������ �÷��̾� ������ ����
                    StartCoroutine("CountDown");
                }
                else if(!realEnd)
                {
                    leftHands.SetActive(true); // �޼� ������
                    rightHands.SetActive(true); // ������ ������
                    crossHair.SetActive(true); // ũ�ν���� ������
                    cycleGuideViews.SetActive(false); // ���̵�� ��ȯ ������ ����



                    preProcessingEnd = true;
                }
            }
        }
        else // �ν� ���� ��
        {
            preProcessingEnd = false;

            leftHands.SetActive(false); // �޼� ������ ����
            rightHands.SetActive(false); // ������ ������ ����
            crossHair.SetActive(false); // ũ�ν���� ������ ����
            cycleGuideViews.SetActive(true); // ���̵�� ��ȯ ������

        }
    }

    IEnumerator CountDown()
    {
        realEnd = true;
        count = 3;
        countDown.SetActive(true);
        for (int i = count; i >= 0; i--)
        {
            if (i == 0)
            {
                countDownText.text = string.Format("START!");
            }
            else
            {
                countDownText.text = string.Format(i.ToString());
            }
            yield return new WaitForSeconds(1f);
        }
        countEnd = true;
        realEnd = false;
        countDown.SetActive(false);
        yield return new WaitForSeconds(1f);
    }
}
