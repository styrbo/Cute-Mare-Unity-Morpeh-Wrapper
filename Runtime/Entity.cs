using CuteMareMorpeh.UnityRelatedComponents;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Collections;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace CuteMareMorpeh
{
    
    [RequireComponent(typeof(EntityProvider))]
    public class Entity : EntityProvider
    {
        private FastList<Collider> _onTriggerEnterColliders;

        private void OnValidate()
        {
            if (GetComponent<EntityProvider>() == null)
                gameObject.AddComponent<EntityProvider>();
        }

        protected override void Initialize()
        {
            _onTriggerEnterColliders = new FastList<Collider>(2); 
            
            base.Initialize();
            
            Entity.GetComponent<GameObjectComponent>(out var exist);
            
            if(exist)
                return;
            
            Entity.AddComponent<GameObjectComponent>();
            var stash = World.Default.GetStash<GameObjectComponent>();
            
            stash.Set(Entity, new GameObjectComponent()
            {
                GameObject = gameObject,
            });
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _onTriggerEnterColliders.Add(other);
            
            var stash = World.Default.GetStash<TriggerEnterCollisions>();

            stash.Set(Entity, new TriggerEnterCollisions
            {
                contacts = _onTriggerEnterColliders,
            });
        }

        private void OnDestroy()
        {
            World.Default.RemoveEntity(Entity);
        }
    }
}