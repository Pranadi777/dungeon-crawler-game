using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private UnityEvent onLeftClick;
    [SerializeField] private UnityEvent onRightClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player left clicks
        OnLeftClick();

    }

    private void OnLeftClick()
    {
        // If the input is left the following will happen
        if (Input.GetMouseButton(0))
        {
            onLeftClick.Invoke();
        }
    }



}
