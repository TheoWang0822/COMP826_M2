using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SideMenuView : MonoBehaviour
{
    public RectTransform sideMenuRect; // ��קSideMenuPanel��RectTransform
    public Button ExitBtn;
    public float slideDuration = 0.3f; // ����ʱ��
    private float menuWidth= 800f; // �˵����
    private bool isOpen = false;
    //private GameObject isSliding = false;

    void Start()
    {
        sideMenuRect.anchoredPosition = new Vector2(-menuWidth, 0); // ��ʼ���������
        ExitBtn.onClick.AddListener(CloseMenu);
    }

    // ToggleMenu�������л��˵�״̬�������߼���
    public void ToggleMenu()
    {
        if (isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    // �򿪲˵��ĸ�������
    private void OpenMenu()
    {
        sideMenuRect.DOAnchorPosX(0, slideDuration).SetEase(Ease.OutCubic); // ������
        isOpen = true;
        ExitBtn.gameObject.SetActive(true);
    }

    // �رղ˵��ĸ�������
    private void CloseMenu()
    {
        sideMenuRect.DOAnchorPosX(-menuWidth, slideDuration).SetEase(Ease.InCubic); // ���󻬳�
        isOpen = false;
        ExitBtn.gameObject.SetActive(false);
    }
}
