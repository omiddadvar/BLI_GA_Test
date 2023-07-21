using MachineLearning.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.Data.DataDebuggerPreview;

namespace MachineLearning.Classes
{
    public  class TrainingData
    {
        private TrainingData _instance;
        public TrainingData GetInstance()
        {
            if(_instance == null)
                _instance = new TrainingData();
            return _instance;
        }

        private const int _MaxDataRows = 100000;
        private List<TrainingTestDataModel> _data;
        public List<TrainingTestDataModel> Data { get => _data; }
        private const string _path = @"D:\E.Heydari\ml-100k\u1.base";
        /// <summary>
        /// 
        /// </summary>
        private TrainingData() 
        {            
            var rawData = _ReadData();
            _data = _ConvertToModel(rawData);
        }

        private RowInfo[] _ReadData()
        {
            MLContext mlContext = new MLContext();
            IDataView data = mlContext.Data.LoadFromTextFile<TrainingTestDataModel>(_path);
            return data.Preview(_MaxDataRows).RowView.ToArray();
        }
        private List<TrainingTestDataModel> _ConvertToModel(RowInfo[] rows)
        {
            var data = new List<TrainingTestDataModel>();
            foreach (var item in rows)
            {
                var dataModel = new TrainingTestDataModel();
                foreach (KeyValuePair<string, object> keyVal in item.Values)
                {
                    dataModel.UserId = keyVal.Key.Equals("UserId") ? (int)keyVal.Value : dataModel.UserId;
                    dataModel.Rating = keyVal.Key.Equals("Rating") ? (int)keyVal.Value : dataModel.Rating;
                    dataModel.MovieId = keyVal.Key.Equals("MovieId") ? (int)keyVal.Value : dataModel.MovieId;
                    dataModel.ExtraInfo = keyVal.Key.Equals("ExtraInfo") ? (long)keyVal.Value : dataModel.ExtraInfo;
                }
                data.Add(dataModel);
            }
            return data;
        }

    }
}
