using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Trigger : MonoBehaviour
{
    public void TriggerSFX(int index)
    {
        Audio_Manager.instance.TriggerSFX(index);
    }
}
