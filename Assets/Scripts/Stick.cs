using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stick : MonoBehaviour
{
    public Animator _stickAnimator;
    public float BlendPower { get; private set; }
    public bool isTense = false;
    [SerializeField] private Ball _ball;
    public bool IsFixed;
    [SerializeField] private float _fixedTimeForJump;
    public float _currentTime;
    [SerializeField] private bool _isWaiting;


    private void Update()
    {
        BlendPower = Mathf.Clamp(BlendPower, 0, 1);
        if (IsFixed == true)
        {
            gameObject.SetActive(true);
            _currentTime += Time.deltaTime;
            if (Input.GetMouseButton(0) && _currentTime > _fixedTimeForJump)
            {
                BlendPower += Time.deltaTime * 2f;
                _stickAnimator.SetFloat("Blend", BlendPower);
            }
                

            
        }
        if(IsFixed == true && Input.GetMouseButtonUp(0) && _currentTime > _fixedTimeForJump)
        {
            StartCoroutine(ReadyToPush());

        }
    
    }


    IEnumerator ReadyToPush()
    {
        while (BlendPower > 0)
        {
            BlendPower -= Time.deltaTime * 10f;
            _stickAnimator.SetFloat("Blend", BlendPower);
            yield return null;
        }
        IsFixed = false;
        _currentTime = 0;
        _ball.PushUpBall();
        gameObject.SetActive(false);
    }





}
