using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Stick _stick;
    [SerializeField] private Transform _stickParent;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if(_stick.IsFixed == false && transform.parent == null)
            {
                Ray ray = new Ray(transform.position, Vector3.forward);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out Wall wall))
                    {
                        _stick.transform.position = new Vector3(
                            _stick.transform.position.x, 
                            transform.position.y,
                            _stick.transform.position.z
                            );
                        transform.DOShakePosition(1f, new Vector3(0, 1f, 0));
                        _rigidbody.useGravity = false;
                        _rigidbody.velocity = Vector3.zero;
                        _stick.gameObject.SetActive(true);
                        transform.parent = _stickParent;
                        transform.position = _stickParent.position;
                        _stick.IsFixed = true;
                    }
                    else if(hit.collider.TryGetComponent(out Block block))
                    {
                        _stick.transform.position = new Vector3(
                            _stick.transform.position.x,
                            transform.position.y,
                            _stick.transform.position.z
                            );
                        _rigidbody.useGravity = false;
                        _rigidbody.velocity = Vector3.zero;
                        _stick.gameObject.SetActive(true);
                        transform.parent = _stickParent;
                        transform.position = _stickParent.position;
                        Invoke("RemoveAttachment", 0.1f);

                    }
                    else if (hit.collider.TryGetComponent(out WinBlock winBlock))
                    {
                        _stick.transform.position = new Vector3(
                            _stick.transform.position.x,
                            transform.position.y,
                            _stick.transform.position.z
                            );
                        _rigidbody.useGravity = false;
                        _rigidbody.velocity = Vector3.zero;
                        _stick.gameObject.SetActive(true);
                        transform.parent = _stickParent;
                        transform.position = _stickParent.position;
                        Invoke("LoadLevel", 0.2f);
                    }
                }
            }
            

        }

    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void RemoveAttachment()
    {
        _rigidbody.useGravity = true;
        _stick.gameObject.SetActive(false);
        transform.parent = null;
    }

    public void PushUpBall()
    {
        transform.parent = null;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

}
