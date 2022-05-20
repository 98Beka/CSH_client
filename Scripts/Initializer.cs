using System;
using System.Net.Http;
using UnityEngine;
using CsharpPool.Assets.Scripts;

namespace CsharpPool.Assets.Scripts {
    public class Initializer : MonoBehaviour {
        private void Awake() {
            StaticDatas.Client = new HttpClient();
            StaticDatas.Client.BaseAddress = new Uri(StaticDatas.Uri);
            StaticDatas.MainOperator = new Operator();
        }
    }
}