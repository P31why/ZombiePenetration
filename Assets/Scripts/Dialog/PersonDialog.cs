using UnityEngine;

public class PersonDialog : MonoBehaviour
{
    [SerializeField]
    private DialogScriptableObject dialogObject;
    [SerializeField]
    private GameObject _dialogUI;
    private bool _isVisible;
    private void Awake()
    {
        _isVisible = false;
        _dialogUI.SetActive(_isVisible);
    }
    private void LateUpdate()
    {
        if (_isVisible)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isVisible = false;
            }
        }
    }
    public void StartTalking()
    {
        _isVisible = true;
        _dialogUI.SetActive(_isVisible);
    }
}
