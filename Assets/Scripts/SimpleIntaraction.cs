using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleIntaraction : IInputInteraction
{
    public float Duration = 0.2f;

    [UnityEditor.InitializeOnLoadMethod]
    private static void Regist()
    {
        InputSystem.RegisterInteraction<SimpleIntaraction>();
    }

    public void Process(ref InputInteractionContext context)
    {
        if (context.timerHasExpired)
            context.Canceled();

        switch (context.phase)
        {
            case InputActionPhase.Waiting:
                if(context.ReadValue<float>() == 1)
                {
                    context.Started();
                    context.SetTimeout(Duration);
                }
                break;
            case InputActionPhase.Started:
                if (context.ReadValue<float>() == -1)
                {
                    context.Performed();
                }
                break;

        }

       
    }

    public void Reset()
    {
        
    }
}
