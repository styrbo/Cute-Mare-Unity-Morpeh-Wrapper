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

        protected override void Initialize()
        {
            base.Initialize();

            Entity.GetComponent<GameObjectReferencesComponent>(out var exist);

            if (exist)
                return;

            Entity.AddComponent<GameObjectReferencesComponent>();
        }
    }
}