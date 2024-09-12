using TMPro;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private string username;

    public void GetUsername()
    {
        username = inputField.text;
        Debug.Log(username);
    }
}



