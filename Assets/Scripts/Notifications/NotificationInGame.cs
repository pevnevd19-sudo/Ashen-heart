using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationInGame : MonoBehaviour
{
    [SerializeField] private TMP_Text notification;
    [SerializeField] private Image notificationBack;
    [SerializeField] private RectTransform rectNotif;
    private float apperanceTime;
    private float apperancePosition;
    private float disapperancePosition;


    private void Start()
    {
        notificationBack.GetComponent<Image>();
        notificationBack.gameObject.SetActive(false);

        apperanceTime = 1f;
        apperancePosition = 915;
        disapperancePosition = 2001;


        rectNotif.anchoredPosition = new Vector2(disapperancePosition, rectNotif.anchoredPosition.y);
    }

    public string SetNotification(string text)
    {
        notification.text = text;
        StartCoroutine(NotificationApperance());
        return text;
    }

    private IEnumerator SmoothApperance()
    {
        float elapsedTime = 0f;
        float startX = rectNotif.anchoredPosition.x;
        float targetX = apperancePosition;

        while (elapsedTime < apperanceTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / apperanceTime;

            t = Mathf.SmoothStep(0, 1, t);
            float newX = Mathf.Lerp(startX, targetX, t);

            rectNotif.anchoredPosition = new Vector2(newX, rectNotif.anchoredPosition.y);

            yield return null;
        }
        rectNotif.anchoredPosition = new Vector2(targetX, rectNotif.anchoredPosition.y);
        yield return new WaitForSeconds(4f);
    }
    private IEnumerator SmoothDisapperance()
    {
        float elapsedTime = 0f;
        float startX = rectNotif.anchoredPosition.x;
        float targetX = disapperancePosition;

        while (elapsedTime < apperanceTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / apperanceTime;

            t = Mathf.SmoothStep(0, 1, t);
            float newX = Mathf.Lerp(startX, targetX, t);

            rectNotif.anchoredPosition = new Vector2(newX, rectNotif.anchoredPosition.y);

            yield return null;
        }
        rectNotif.anchoredPosition = new Vector2(targetX, rectNotif.anchoredPosition.y);
    }


    private IEnumerator NotificationApperance()
    {
        notificationBack.gameObject.SetActive(true);
        StartCoroutine(SmoothApperance());

        yield return new WaitForSeconds(3f);

        StartCoroutine(SmoothDisapperance());
        yield return new WaitForSeconds(2f);
        notificationBack.gameObject.SetActive(false);
    }
}
