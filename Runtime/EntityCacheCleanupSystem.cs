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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EntityCacheCleanupSystem))]
    internal class EntityCacheCleanupSystem : CleanupSystem
    {
        public override void OnAwake()
        {
            
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in World.Filter.With<GameObjectComponent>())
            {
                ref var triggerEnterCollisions = ref entity.GetComponent<TriggerEnterCollisions>(out var hasTriggerEnterCollisions);
                
                if (hasTriggerEnterCollisions)
                {
                    triggerEnterCollisions.contacts.Clear();
                    entity.RemoveComponent<TriggerEnterCollisions>();
                }
            }
        }
    }
}