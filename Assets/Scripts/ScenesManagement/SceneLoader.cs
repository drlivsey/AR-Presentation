using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ARPresentation.ScenesManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private String m_sceneName;

        private void Awake()
        {
            if (m_sceneName.Trim().Equals(string.Empty))
            {
                throw new ArgumentException("Scene name is invalid!");
            }
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(m_sceneName, LoadSceneMode.Single);
        }
    }
}