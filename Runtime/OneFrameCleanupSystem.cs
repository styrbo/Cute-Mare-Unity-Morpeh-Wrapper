using System;
using System.Linq;
using CuteMareMorpeh.UnityRelatedComponents;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace CuteMareMorpeh
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OneFrameCleanupSystem))]
    public sealed class OneFrameCleanupSystem : CleanupSystem
    {

        private FastList<Type> _oneFrameComponentTypes;
        private FastList<Stash> _stashes;

        public override void OnAwake() {
        
            _oneFrameComponentTypes = new FastList<Type>();
            _stashes = new FastList<Stash>();
        
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
        
            foreach (var type in types) {
            
                if (typeof(IOneFrameComponent).IsAssignableFrom(type))
                {
                    if(type.IsClass || type.IsInterface)
                        continue;
                
                    _oneFrameComponentTypes.Add(type);
                }
            }
        }

        public override void OnUpdate(float deltaTime)
        {

            foreach (var type in _oneFrameComponentTypes)
            {
                _stashes.Add(World.GetReflectionStash(type));
            }

            foreach (var entity in World.Filter.With<GameObjectComponent>())
            {
                foreach (var stash in _stashes)
                {
                    if(stash.Has(entity))
                        stash.Remove(entity);
                }
            }
            
            _stashes.Clear();
        }
    }
}