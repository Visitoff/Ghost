using UnityEngine;

public class GhostTarget : MonoBehaviour
{
    private bool ghostCam;
    public GameObject Ghost;
    
    void Update()
    {
        if (ghostCam = true)
        {
            Debug.Log("1");
            Destroy(Ghost, 5f);
        }
    }
    void OnBecameVisible()
    {
        ghostCam = true;
    }
}
