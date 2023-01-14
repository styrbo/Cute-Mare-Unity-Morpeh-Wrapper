using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using Entity = CuteMareMorpeh.Entity;

namespace CuteMareMorpeh
{
    [RequireComponent(typeof(Entity))]
    public class MPMonoProvider<T> : MonoProvider<T> where T : struct, IComponent
    {
        
    }
}