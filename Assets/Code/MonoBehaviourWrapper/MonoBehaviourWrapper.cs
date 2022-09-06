using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public abstract class MonoBehaviourWrapper : MonoBehaviour
{
    private IEnumerable<ISubscriber> _subscribers;
    private IEnumerable<IFixedUpdate> _fixedUpdates;    
    private IEnumerable<IUpdate> _updates;


    protected void SetDependencies(object[] dependencies)
    {
        dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Init());
        _subscribers = dependencies.OfType<ISubscriber>();
        _fixedUpdates = dependencies.OfType<IFixedUpdate>();
        _updates = dependencies.OfType<IUpdate>();
    }

    
    private void OnEnable()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.Subscribe();
        }
    }


    private void OnDisable()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.Unsubscribe();
        }
    }


    private void FixedUpdate()
    {
        foreach (IFixedUpdate fixedUpdate in _fixedUpdates)
        {
            fixedUpdate.FixedUpdate();
        }
    }


    private void Update()
    {
        foreach (IUpdate update in _updates)
        {
            update.Update();
        }
    }
}