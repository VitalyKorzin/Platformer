using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _target.position.x, Time.deltaTime), 
                                         Mathf.Lerp(transform.position.y, _target.position.y, Time.deltaTime), -10f);
    }
}