using UnityEngine;

namespace DigitalPenguin.Unity.Persistence
{
    public abstract class PlayerPrefBase<T> : MonoBehaviour
    {
        [Space(5)]
        public string prefName = "MyPlayerPref";
        [Space(5)]
        public bool readOnAwake = false;

        private T value;
        public T Value { get => this.value; set => this.value = value; }

        void Awake()
        {
            if (readOnAwake)
            {
                Load();
            }
        }

        public void Save(T value)
        {
            this.Value = value;
            Save();
        }

        public void Save()
        {
            SaveInternal();
            Debug.Log("Saved PlayerPref \"" + prefName + "\" with value: " + this.Value);
        }

        protected abstract void SaveInternal();

        public void Load()
        {
            LoadInternal();
            Debug.Log("Read from PlayerPref \"" + prefName + "\": " + this.Value);
        }

        protected abstract void LoadInternal();

        protected void UpdateFromEditorInput(T userValue)
        {
            this.Value = userValue;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(prefName);
        }
    }
}