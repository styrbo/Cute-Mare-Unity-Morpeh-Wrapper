using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CuteMareMorpeh.UnityRelatedComponents
{
    /// <summary>
    /// add this component for all entities that need to be destroyed
    /// </summary>
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct GameObjectReferencesComponent : IComponent
    {
        public GameObject GameObject;
        public Rigidbody Rigidbody;
    }
}