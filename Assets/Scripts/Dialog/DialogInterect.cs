using UnityEngine;

public class DialogInterect : MonoBehaviour
{
    public LayerMask layer;
    private Transform _camera;
    private RaycastHit _hit;
    private void Awake()
    {
        _camera = Camera.main.transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartDialog();
        }
    }
    private void StartDialog()
    {
        if (Physics.Raycast(_camera.transform.position,_camera.transform.forward,out _hit,layer))
        {
            if (_hit.collider != null)
            {
                if (_hit.collider.tag == "Dialog")
                {
                    _hit.collider.GetComponent<PersonDialog>().StartTalking();
                }
            }
        }
    }
}
