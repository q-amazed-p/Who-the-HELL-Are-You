using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField] TMP_Text message;

    public void PushNotification(string incomingMessage)
    {
        message.text = incomingMessage;


    }


}
