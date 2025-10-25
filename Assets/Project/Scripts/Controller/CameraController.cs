using UnityEngine;
using DG.Tweening; // µ¼Èë DOTween

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 overviewPosition = new Vector3(-14.59f, 13.43f, -8.11f);
    public Vector3 overviewRotation = new Vector3(22.2f, 49.7f, 0f);
    private Vector3 baseFloorPosition = new Vector3(-11.8f, 17.75f, 2.64f);
    private Vector3 floorRotation = new Vector3(30f, 90f, 0f);
    private GameObject floorObj;
    private float[] floorYOffsets = new float[5]
    {
        -8f,
        -6f,
        -4f,
        -2f,
        0f
    };

    public float moveDuration = 1f;
    private float returnTimer = 0f;
    private const float returnDelay = 5f;
    private bool isViewingFloor = false;

    void Start()
    {
        if (cameraTransform == null)
        {
            return;
        }
        cameraTransform.position = overviewPosition;
        cameraTransform.rotation = Quaternion.Euler(overviewRotation);
    }

    void OnEnable()
    {
        EventsHub.FloorClicked += OnFloorClicked;
    }

    void OnDisable()
    {
        EventsHub.FloorClicked -= OnFloorClicked;
    }

    private void OnFloorClicked(Floor floor)
    {
        if (cameraTransform == null) return;
        if (floor.gameObject == floorObj)
        {
            floorObj = null;
            ReturnToOverview();
            return;
        }

        floorObj = floor.gameObject;

        if (floor == null)
        {
            ReturnToOverview();
            return;
        }

        int floorNumber = floor.id;

        if (floorNumber >= 1 && floorNumber <= 5)
        {
            Vector3 targetPosition = baseFloorPosition;
            targetPosition.y += floorYOffsets[floorNumber - 1];
            cameraTransform.DOMove(targetPosition, moveDuration).SetEase(Ease.InOutSine);
            cameraTransform.DORotate(floorRotation, moveDuration).SetEase(Ease.InOutSine);
            returnTimer = returnDelay;
            isViewingFloor = true;
        }
    }

    void Update()
    {
        /*
        if (isViewingFloor)
        {
            returnTimer -= Time.deltaTime;
            if (returnTimer <= 0f)
            {
                ReturnToOverview();
            }
        }*/
    }
    public void ReturnToOverview()
    {
        if (cameraTransform == null) return;

        cameraTransform.DOMove(overviewPosition, moveDuration).SetEase(Ease.InOutSine);
        cameraTransform.DORotate(overviewRotation, moveDuration).SetEase(Ease.InOutSine);
        isViewingFloor = false;
    }
}