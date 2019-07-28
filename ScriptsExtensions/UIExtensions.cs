/*
 * Created by Alexander Sosnovskiy. May 3, 2016
 */
using System;
using UnityEngine;
using UnityEngine.UI;


namespace Client.Scripts.Algorithms.ScriptsExtensions
{
    public static class UiExtensions
    {
        public static void SetOnClick(this Button go, Action<GameObject> handler)
        {
            go.onClick.AddListener(() =>
            {
                handler?.Invoke(go.gameObject);
            });
        }

        public static void SetOnClick(this GameObject go, Action<GameObject> handler)
        {
            var eventHandler = go.GetComponent<Button>();

            if (eventHandler == null)
                eventHandler = go.AddComponent<Button>();

            eventHandler.onClick.AddListener(() =>
            {
                handler?.Invoke(go);
            });
        }
    }
}