﻿using System.Pooling;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unity.Pooling
{
    public class AsyncGameObjectPool<TKey> : AsyncUnityPoolBase<TKey, GameObject>
    {
        public static readonly AsyncGameObjectPool<TKey> Shared  = new AsyncGameObjectPool<TKey>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override void ReturnPreprocess(GameObject instance)
        {
            if (instance.activeSelf)
                instance.SetActive(false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected sealed override UniTaskFunc<GameObject> GetDefaultInstantiator()
            => Instantiator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UniTask<GameObject> Instantiator()
        {
            var go = new GameObject();
            return UniTask.FromResult(go);
        }
    }
}
