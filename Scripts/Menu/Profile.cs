using System.Collections;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace CsharpPool.Assets.Scripts {
    public class Profile : MonoBehaviour
    {
        [SerializeField] private InputField userNickname;
        [SerializeField] private InputField userName;
        [SerializeField] private InputField userAge;
        [SerializeField] private InputField userTelegram;
        [SerializeField] private float BtnOffTime = 10;
        Operator oprtr;

        private void Awake() {
            oprtr = StaticDatas.MainOperator;
            userNickname.text = oprtr.Nickname;
            userName.text = oprtr.Name;
            userAge.text = oprtr.Age.ToString();
            userTelegram.text = oprtr.Telegram;
        }

        public async void SaveUserDataChanges(GameObject btn) {
            StartCoroutine(OffThanOn(btn));
            oprtr.Name = userName.text;
            int age = 0;
            try {
                age = int.Parse(userAge.text);
            } catch {
                userAge.text = "Incorect value";
            }
            if (age > 150 || age < 0)
                userAge.text = "Incorect value";
            else
            oprtr.Age = age;
            oprtr.Telegram = userTelegram.text;
            var json = JsonConvert.SerializeObject(oprtr);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await StaticDatas.Client.PostAsync("/changeOperatorData", data);
        }

        private IEnumerator OffThanOn( GameObject gObj) {
            var btn = gObj.GetComponent<Button>();
            var img = gObj.GetComponent<Image>();
            var txt = gObj.transform.GetChild(0).GetComponent<Text>();
            Color colorTmp = img.color;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
            string textTmp = txt.text;
            txt.text = "done";
            btn.enabled = false;
                yield return new WaitForSeconds(BtnOffTime);
            btn.enabled = true;
            img.color = colorTmp;
            txt.text = textTmp;
        }
    }
}
