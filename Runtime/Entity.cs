using CuteMareMorpeh.UnityRelatedComponents;
using JetBrains.Annotations;
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

            Entity.GetComponent<GameObjectReferencesComponent>(out var exist);

            if (exist)
                return;

            Entity.AddComponent<GameObjectReferencesComponent>();

            var rb = CreateRbComponent();

            var stash = World.Default.GetStash<GameObjectReferencesComponent>();

            stash.Set(Entity, new GameObjectReferencesComponent()
            {
                GameObject = gameObject,
                Rigidbody = rb,
            });
        }

        [CanBeNull]
        private Rigidbody CreateRbComponent()
        {
            var rb = GetComponent<Rigidbody>();

            if (rb == null)
                return null;

            var stash = World.Default.GetStash<PhysicBody>();

            stash.Set(Entity, new PhysicBody()
            {
                Position = rb.position,
                Rotation = rb.rotation,
            });

            return rb;
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