using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _positionObject;

    private Rigidbody _rigidbodyObject;
    private MeshCollider _colliderObject;
    private float _distance = 2f;
    private bool IsTaken;

    private void Update()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distance) && hit.collider.tag == "Test"&& IsTaken==false)
        {
            _rigidbodyObject = hit.collider.gameObject.GetComponent<Rigidbody>();
            _colliderObject = hit.collider.gameObject.GetComponent<MeshCollider>();

            if (Input.GetKeyDown(KeyCode.E) && IsTaken != true)
            {
                Take_Item();

            }
            else if (Input.GetKeyDown(KeyCode.E) && IsTaken == true)
            {
                Push();
                Take_Item();
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Push();
        }

        if (_rigidbodyObject != null)
        {
            if (_rigidbodyObject.isKinematic != false)
                _rigidbodyObject.gameObject.transform.position = _positionObject.position;
        }
    }

    public void Take_Item()
    {
        IsTaken = true;
        _colliderObject.isTrigger = true;
        _rigidbodyObject.isKinematic = true;
        _rigidbodyObject.MovePosition(_positionObject.position);
    }

    public void Push()
    {
        IsTaken = false;
        _colliderObject.isTrigger = false;
        _rigidbodyObject.useGravity = true;
        _rigidbodyObject.isKinematic = false;
        _rigidbodyObject.AddForce(Camera.main.transform.forward * 10);
    }
}
