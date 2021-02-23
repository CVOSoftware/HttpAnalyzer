using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;
using HttpAnalyzer.Models.Contract;
using HttpAnalyzer.Models.Data;

namespace HttpAnalyzer.Models.View
{
    internal class ResponseStatusPanelViewModel : BindableObject, IDataSubscriber<StatusPanelModel>
    {
        private const string STATUS_LABEL = "Status";

        private const string TIME_LABEL = "Time, ms";

        private const string SIZE_LABEL = "Size, MB";

        private const string SAVE_RESPONSE_LABEL = "Save response";

        private bool _enableSaveCommand;

        private int _status;

        private int _time;

        private double _size;

        private RelayCommand _saveResponseCmd;

        public ResponseStatusPanelViewModel()
        {
            ModelHub.Instance.Subscribe<ResponseStatusPanelViewModel, StatusPanelModel>(this);
        }

        public string StatusLabel => STATUS_LABEL;

        public string TimeLabel => TIME_LABEL;

        public string SizeLabel => SIZE_LABEL;

        public string SaveResponseLabel => SAVE_RESPONSE_LABEL;

        public int Status
        {
            get => _status;
            set => SetValue(ref _status, value);
        }

        public int Time
        {
            get => _time;
            set => SetValue(ref _time, value);
        }

        public double Size
        {
            get => _size;
            set => SetValue(ref _size, value);
        }

        public RelayCommand SaveResponseCmd => RelayCommand.Register(ref _saveResponseCmd, OnSaveResponse, CanSaveResponse);

        public void OnSaveResponse(object obj)
        {

        }

        public bool CanSaveResponse(object o) => _enableSaveCommand && _size > 0;

        #region IDataSubscriber<ActionPanelModel>

        public void IsNewNotification(StatusPanelModel model)
        {

        }

        public void IsUpdateNotification(StatusPanelModel model)
        {
            Status = model.StatusCode;
            Time = (int)model.RequestTime.TotalMilliseconds;
            Size = Math.Round(model.Size / 1048576.0, 2);
            _enableSaveCommand = true;
        }

        #endregion
    }
}