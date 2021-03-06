using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using ViewModel;
using Components.Utils;
using TMPro;
using System;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using Unity.Collections;

namespace Components
{
    public class TrackedButtonDisplay : MonoBehaviour
    {
        [Header("Data")]
        public TrackManagerViewModel trackImageManager;

        [Header("UI")]
        public Button trackInput;
        public TextMeshProUGUI trackLabel;

        void Start()
        {
            trackImageManager.currentTrackInterfaceActive
                .Subscribe(OnButtonActive)
                .AddTo(this);
            
            trackImageManager.currentTrackLabel
                .Subscribe(OnTrackLabelChange)
                .AddTo(this);
            
            trackImageManager.currentTrackInterfaceActive.Value = true;
        }

        private void OnTrackLabelChange(string text)
        {
            trackLabel.text = text;
        }

        void OnButtonActive(bool isActive)
        {
            trackInput.enabled = isActive;
            trackImageManager.currentTrackLabel.Value = "Play Capture";
        }
    }
}
