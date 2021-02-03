namespace HttpAnalyzer.Models.Contract
{
    internal interface IDataSubscriber<TModel>
    {
        void IsNewNotification(TModel model);

        void IsUpdateNotification(TModel model);
    }
}
