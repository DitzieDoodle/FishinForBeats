using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace DigitalPenguin.Unity.Persistence
{
    [AddComponentMenu("Int PlayerPref")]
    public class PlayerPrefInt : PlayerPrefBase<int>
    {
        [Serializable]
        public class PlayerPrefIntEvent : UnityEvent<int>
        {
        }

        [Space(10)]
        public PlayerPrefIntEvent onLoad;
        [Space(10)]
        public UpdateLabel updateLabel;

        protected override void LoadInternal()
        {
            this.Value = PlayerPrefs.GetInt(prefName);
            onLoad?.Invoke(this.Value);

            if (updateLabel.textMeshProText != null)
            {
                string text = this.Value.ToString();
                if (updateLabel.format != null && updateLabel.format.Length > 0)
                {
                    text = this.Value.ToString(updateLabel.format);
                }
                updateLabel.textMeshProText.text = text;
            }
        }

        protected override void SaveInternal()
        {
            PlayerPrefs.SetInt(prefName, this.Value);
        }
    }

    [Serializable]
    public class UpdateLabel
    {
        public string format;
        public TextMeshProUGUI textMeshProText;
    }
}