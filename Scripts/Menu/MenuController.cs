using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CsharpPool.Assets.Scripts {
    public class MenuController : MonoBehaviour {
        private enum CanvasType{ SingInCanvas, MainCanvas, ProfileCanvas, SettignsCanvas, AboutCanvas}
        [SerializeField] private CanvasType allCanvases = CanvasType.SingInCanvas;
        [SerializeField] private List<GameObject> canvases = new List<GameObject>();

        private void SwitchCanvas(CanvasType canvasType) {
            foreach(var cv in canvases)
                cv.SetActive(false);
            canvases[(int)canvasType].SetActive(true);
        }

        private void Awake() {
            SwitchCanvas(allCanvases);
        }

        public void OpenProfileCanvas() {
            SwitchCanvas(CanvasType.ProfileCanvas);
        }

        public void OpenMainCanvas() {
            SwitchCanvas(CanvasType.MainCanvas);
        }

        public void OpenSettingsCanvas() {
            SwitchCanvas(CanvasType.SettignsCanvas);
        }

        public void OpenAboutCanvas() {
            SwitchCanvas(CanvasType.AboutCanvas);
        }

        public void OpenSingInCanvas() {
            SwitchCanvas(CanvasType.SingInCanvas);
        }

        public void StartGame() {
            SceneManager.LoadScene(1);
        }

        public void OpenMainMenuScene() {
            SceneManager.LoadScene(0);
        }

        public void QuitGame() {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
