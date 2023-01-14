using System;
using Scellecs.Morpeh.Collections;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CuteMareMorpeh.UnityRelatedComponents
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct TriggerEnterCollisions : IOneFrameComponent
    {
        public FastList<Collider> contacts;
    }
}