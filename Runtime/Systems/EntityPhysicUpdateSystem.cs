using CuteMareMorpeh.UnityRelatedComponents;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Profiling;

namespace CuteMareMorpeh.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EntityPhysicUpdateSystem))]
    internal class EntityPhysicUpdateSystem : FixedUpdateSystem
    {
        public override void OnAwake()
        {
            
        }

        public override void OnUpdate(float deltaTime)
        {
            Profiler.BeginSample("apply physic");
            //apply entity changes
            foreach (var entity in World.Filter.With<PhysicBody>())
            {
                ref var gameObject = ref entity.GetComponent<GameObjectReferencesComponent>();
                ref var physicBody = ref entity.GetComponent<PhysicBody>();
                
                if(gameObject.Rigidbody.position != physicBody.Position)
                    gameObject.Rigidbody.MovePosition(physicBody.Position);
                
                if(gameObject.Rigidbody.rotation != physicBody.Rotation)
                    gameObject.Rigidbody.MoveRotation(physicBody.Rotation);
            }
            Profiler.EndSample();
     
            Profiler.BeginSample("cleanup collisions cache");
            //cleanup trigger cache
            foreach (var entity in World.Filter.With<TriggerEnterCollisions>())
            {
                ref var triggerEnterCollisions = ref entity.GetComponent<TriggerEnterCollisions>(out var hasTriggerEnterCollisions);
                
                if (hasTriggerEnterCollisions)
                {
                    triggerEnterCollisions.contacts.Clear();
                    entity.RemoveComponent<TriggerEnterCollisions>();
                }
            }
            Profiler.EndSample();
        }
    }
}