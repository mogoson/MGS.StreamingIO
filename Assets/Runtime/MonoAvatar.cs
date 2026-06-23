/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoAvatar.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/20/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.StreamingReader
{
    /// <summary>
    /// Avatar of MonoBehaviour for casual use.
    /// </summary>
    public sealed class MonoAvatar : MonoBehaviour, IDisposable
    {
        /// <summary>
        /// Create one instance of MonoAvatar.
        /// (Should hold the instance and dispose it if no longer needed.)
        /// </summary>
        /// <returns></returns>
        public static MonoAvatar CreateOne()
        {
            var avatar = new GameObject(nameof(MonoAvatar)).AddComponent<MonoAvatar>();
            DontDestroyOnLoad(avatar.gameObject);
            return avatar;
        }

        public static void WaitRoutine(IEnumerator routine)
        {
            var avatar = CreateOne();
            avatar.StartCoroutine(Wait());
            IEnumerator Wait()
            {
                yield return routine;
                avatar.Dispose();
            }
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}