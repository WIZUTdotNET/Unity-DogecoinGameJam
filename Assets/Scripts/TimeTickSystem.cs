using System;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    public class OnTickEvents : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEvents> OnTick;
    
    private const float maxTick = .5f;
    private int tick;
    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= maxTick)
        {
            tickTimer -= maxTick;
            tick++;
            if (OnTick != null)
            {
                OnTick(this, new OnTickEvents()
                {
                    tick = tick
                });
            }
        }
    }
}
