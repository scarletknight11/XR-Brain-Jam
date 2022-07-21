// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.GettingStarted
{
    //Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
    public class HighlightAtGaze : MonoBehaviour, IGazeFocusable
    {
        
        public GameObject eyeTrackUI;
        private bool turnEyesOn;

        //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
        public void GazeFocusChanged(bool hasFocus)
        {
            if (hasFocus)
            {
                turnEyesOn = true;
                print("looking");
            }
        }

        void Start()
        {
            turnEyesOn = false;
            eyeTrackUI.SetActive(false);
        }

        void Update()
        {
            if (turnEyesOn)
            {
                eyeTrackUI.SetActive(true);
                turnEyesOn = false;
            }
        }
    }
}
