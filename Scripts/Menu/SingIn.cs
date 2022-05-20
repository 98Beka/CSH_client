using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPool.Assets.Scripts {
    public class SingIn : MonoBehaviour {

        [SerializeField] private GameObject createAccountPanel;
        [SerializeField] private InputField secondPasswordUI;
        [SerializeField] private InputField firstPasswordUI;
        [SerializeField] private GameObject singInPanel;
        [SerializeField] private Text messegeUI;
        private MenuController menuController;
        private float MessegeShowingTime = 1;

        private void Awake() {
            singInPanel.SetActive(false);
            createAccountPanel.SetActive(false);
            menuController = FindObjectOfType<MenuController>();
        }

        public async void CreatOrSingIn(InputField nickName) {
            StaticDatas.MainOperator = await GetOperatorFromDB(nickName.text.ToLower());
            if(StaticDatas.MainOperator != null) {
                singInPanel.SetActive(true);
                createAccountPanel.SetActive(false);
            } else {
                StaticDatas.MainOperator.Nickname = nickName.text;
                createAccountPanel.SetActive(true);
                singInPanel.SetActive(false);
            }
        }

        private async Task<Operator> GetOperatorFromDB(string nickName) {
            var result = await StaticDatas.Client.PostAsync("/getOperator", new StringContent(nickName)); 
            string resString = await result.Content.ReadAsStringAsync();
            if (resString == "null")
                return null;
            else 
                return JsonConvert.DeserializeObject<Operator>(resString);
        }

        public void OpenMenu(InputField password) {
            if (password.text ==  StaticDatas.MainOperator.Password)
                menuController.OpenMainCanvas();
            else
                StartCoroutine(WaitAndCloseMessege("wrong password"));
        }

        public async void CreateAccount() {
            if (firstPasswordUI.text == secondPasswordUI.text) {
                StaticDatas.MainOperator.Password = firstPasswordUI.text;
                var json = JsonConvert.SerializeObject(StaticDatas.MainOperator);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                await StaticDatas.Client.PostAsync("/addUser", data);
                menuController.OpenMainCanvas();
            } else {
                StartCoroutine(WaitAndCloseMessege("pawords aren't the same"));
            }
        }

        private IEnumerator WaitAndCloseMessege(string messege) {
            messegeUI.text = messege;
            yield return new WaitForSeconds(MessegeShowingTime);
            messegeUI.text = string.Empty;
        }
    }
}