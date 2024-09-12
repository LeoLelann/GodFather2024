using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PosManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI inputPos;
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        print(inputName.text);
        print(int.Parse(inputPos.text));
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputPos.text));
    }

}
