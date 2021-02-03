using System;
using System.Collections.Generic;

namespace HttpAnalyzer.Models
{
    internal class ModelSubscriberHub
    {
        private object _model;

        public ModelSubscriberHub(object model)
        {
            _model = model;
            Subscribers = new List<object>();
        }

        public List<object> Subscribers { get; }

        public void Subscribe(object subscriber, Action<object, object> addedAction)
        {
            if(Subscribers.Contains(subscriber) == false)
            {
                Subscribers.Add(subscriber);
                addedAction?.Invoke(subscriber, _model);
            }
        }

        public void UnSubscribe(object subscriber)
        {
            if (Subscribers.Contains(subscriber))
            {
                Subscribers.Remove(subscriber);
            }
        }

        public void Update(object model, Action<object, object> updatedAction)
        {
            _model = model;

            foreach (var subscriber in Subscribers)
            {
                updatedAction?.Invoke(subscriber, _model);
            }
        }

        public void UpdateWithIgnore(object ignored, object model, Action<object, object> updatedAction)
        {
            _model = model;

            foreach (var subscriber in Subscribers)
            {
                if(subscriber.Equals(ignored))
                {
                    continue;
                }

                updatedAction?.Invoke(subscriber, _model);
            }
        }
    }
}