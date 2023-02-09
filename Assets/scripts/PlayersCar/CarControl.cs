using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CarControl : MonoBehaviour
{

    PlayerControls controls;

    Vector2 move;

    public GameObject[] Lights;



    public void Awake()
    {
        controls = new PlayerControls();

        //controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        //controls.Gameplay.Lights.performed += ctx => LightsOn();
        controls.Gameplay.Lights.canceled += ctx => LightsOff();
    }

    

    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime * 5;
        transform.Translate(m, Space.World);
    }

    public void onMove(InputAction.CallbackContext ctx) => move = ctx.ReadValue<Vector2>();

    public void LightsOn()
    {
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 5;
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 1.1f;
    }

    void LightsOff()
    {
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
        Lights[0].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
        Lights[1].GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightOuterRadius = 0.8f;
    }


    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
