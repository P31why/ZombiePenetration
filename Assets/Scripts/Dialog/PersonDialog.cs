using UnityEngine;
using TMPro;
public class PersonDialog : MonoBehaviour
{
    [SerializeField]
    private DialogScriptableObject dialogObject;
    [SerializeField]
    private GameObject _dialogUI;
    [SerializeField]
    private TMP_Text _textUI;
    [SerializeField]
    private TMP_Text _nameUI;
    private bool _isVisible;
    private int textCounter;
    GameObject camera;
    private void Awake()
    {
        _isVisible = false;
        _dialogUI.SetActive(_isVisible);
        textCounter = 0;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void StartTalking()
    {
        _isVisible = true;
        _dialogUI.SetActive(_isVisible);
        Cursor.lockState = CursorLockMode.Confined;
        camera.GetComponent<PlayerCamera>().enabled=false;
        ViewDialogText(dialogObject.personName, dialogObject.dialogs[textCounter]);
        textCounter++;
    }
    public void Talking()
    {
        if (textCounter < dialogObject.dialogs.Length)
        {
            ViewDialogText(dialogObject.personName, dialogObject.dialogs[textCounter]);
            textCounter++;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            _dialogUI.SetActive(false);
            camera.GetComponent<PlayerCamera>().enabled = true;
            textCounter = 0;
        }
    }
    private void ViewDialogText(string name, string text)
    {
        _nameUI.text = name;
        _textUI.text = text;
    }
}
