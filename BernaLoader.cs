using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _Scripts.Utilities {
    /// <summary>
    /// Handles transitioning between scenes with a loading screen
    /// </summary>
    public class BernaLoader : PersistentSingleton <BernaLoader> {
        // TODO: import into Project Bernadetta for later usage

        [Required]
        public int loadingScene;
        protected override void Awake() {
            base.Awake();
        }
        
        public void TransitionTo(string sceneName) {
            StartCoroutine(TransitionToCoroutine(sceneName));
        }
        
        public void TransitionTo(int sceneIndex) {
            StartCoroutine(TransitionToCoroutine(sceneIndex));
        }
        
        private IEnumerator TransitionToCoroutine(string sceneName) {
            yield return SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
            LoadingSceneController.Instance.Enable();
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            // Wait for 5 seconds
            yield return new WaitForSeconds(5);
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            LoadingSceneController.Instance.Disable();
            yield return SceneManager.UnloadSceneAsync(loadingScene);
        }
        
        private IEnumerator TransitionToCoroutine(int sceneIndex) {
            yield return SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
            LoadingSceneController.Instance.Enable();
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            // Wait for 5 seconds
            yield return new WaitForSeconds(5);
            yield return SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            LoadingSceneController.Instance.Disable();
            yield return SceneManager.UnloadSceneAsync(loadingScene);
        }
    }


}