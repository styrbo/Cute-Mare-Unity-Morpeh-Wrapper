using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CuteMareMorpeh.UnityRelatedComponents
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PhysicBody : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
    
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PhysicBodyPathTracerComponent : IComponent
    {
        public Vector3 PreviewFramePosition;
        public FastList<RaycastHit> QueryHits;
    }
}