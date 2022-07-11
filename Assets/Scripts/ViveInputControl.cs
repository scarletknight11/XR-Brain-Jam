using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;


public class ViveInputControl : SteamVR_LaserPointer{

    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);

        Debug.Log("clicky");
        
    }
    
}
