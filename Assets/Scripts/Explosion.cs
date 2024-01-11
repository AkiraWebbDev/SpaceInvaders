using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void FinishedExplosion()
    {
        Destroy(gameObject);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
