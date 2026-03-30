using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] string[] timelineTextLines;
    int currentLine = 0;

    public void NextDialogLine()
    {
        currentLine++;
        if(currentLine < timelineTextLines.Length)
            dialogText.text = timelineTextLines[currentLine];
    }
}
