using System;
using System.Collections.Generic;

using HttpAnalyzer.Models.Contract;

namespace HttpAnalyzer.Models
{
    internal class ModelHub
    {
        #region Implementation Singleton

        private static ModelHub _instance;

        private static object _sync;

        static ModelHub()
        {
            _sync = new object();
        }

        public static ModelHub Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new ModelHub();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region Implementation of the subscription logic

        private Dictionary<Type, ModelSubscriberHub> _data;

        private ModelHub()
        {
            _data = new Dictionary<Type, ModelSubscriberHub>();
        }

        public void Register<TModel>(TModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var type = typeof(TModel);

            if (_data.ContainsKey(type) == false)
            {
                var item = new ModelSubscriberHub(model);

                _data.Add(type, item);
            }
        }

        public void Subscribe<TSubscriber, TModel>(TSubscriber subscriber)
            where TSubscriber : IDataSubscriber<TModel>
        {
            if (subscriber == null)
            {
                throw new NullReferenceException();
            }

            var modelType = typeof(TModel);

            if (_data.ContainsKey(modelType))
            {
                var subscriberHub = _data[modelType];

                subscriberHub.Subscribe(subscriber, (s, m) =>
                {
                    ((TSubscriber)s).IsNewNotification((TModel)m);
                });
            }
        }

        public void UnSubscribe<TSubscriber, TModel>(TSubscriber subscriber)
            where TSubscriber : IDataSubscriber<TModel>
        {
            if (subscriber == null)
            {
                throw new NullReferenceException();
            }

            var modelType = typeof(TModel);

            if (_data.ContainsKey(modelType))
            {
                var subscriberHub = _data[modelType];

                subscriberHub.UnSubscribe(subscriber);
            }
        }

        public void Update<TSubscriber, TModel>(TModel model)
            where TSubscriber : IDataSubscriber<TModel>
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }

            var modelType = typeof(TModel);

            if (_data.ContainsKey(modelType))
            {
                var subscriberHub = _data[modelType];

                subscriberHub.Update(model, (s, m) =>
                {
                    ((TSubscriber)s).IsUpdateNotification((TModel)m);
                });
            }
        }

        public void UpdateWithIgnore<TSubscriber, TModel>(TSubscriber subscriber, TModel model)
            where TSubscriber : IDataSubscriber<TModel>
        {
            if (subscriber == null || model == null)
            {
                throw new NullReferenceException();
            }

            var modelType = typeof(TModel);

            if (_data.ContainsKey(modelType))
            {
                var subscriberHub = _data[modelType];

                subscriberHub.UpdateWithIgnore(subscriber, model, (s, m) =>
                {
                    ((TSubscriber)s).IsUpdateNotification((TModel)m);
                });
            }
        }

        #endregion
    }
}
