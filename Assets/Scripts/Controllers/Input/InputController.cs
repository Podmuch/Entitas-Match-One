﻿using UnityEngine;

public class InputController : MonoBehaviour
{

    Contexts _contexts;

    void Awake()
    {
        _contexts = Contexts.sharedInstance;
    }

    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            _contexts.input.isBurstMode = !_contexts.input.isBurstMode;
        }

        var input = _contexts.input.isBurstMode ? 
                    Input.GetMouseButton(0) : Input.GetMouseButtonDown(0);

        if (input)
        {
            var pressPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(pressPosition, Vector2.zero, 100);
            if (hit.collider != null)
            {
                var pos = hit.collider.transform.position;
                _contexts.input.CreateEntity().AddPressPoint((int)pos.x, (int)pos.y);
            }
        }
    }
}
