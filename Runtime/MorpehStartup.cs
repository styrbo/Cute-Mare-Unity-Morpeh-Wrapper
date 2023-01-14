using UnityEngine;

namespace CuteMareMorpeh
{
    public class MorpehStartup : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}