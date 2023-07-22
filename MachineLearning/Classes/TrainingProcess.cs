using BLI_GA_Test.Classes;
using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Log;
using BLI_GA_Test.Models;
using MachineLearning.Classes.MAE;
using MachineLearning.Classes.Precision;
using MachineLearning.Classes.Recall;
using MachineLearning.Interfaces;
using MachineLearning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Classes
{
    public class TrainingProcess : IRunnable
    {
        private TrainingData _trainingData;
        private DataHolder _dataHolder;
        private ActiveUser _AU;
        private TextLog _logger;
        public TrainingProcess()
        {
            _trainingData = TrainingData.GetInstance();
            _dataHolder = DataHolder.GetInstance();
            _dataHolder.TrainingUsers = (from user in _dataHolder.Users
                                         join trainData in _trainingData.Data on user.UserId equals trainData.UserId
                                         select user).ToList();
            _AU = ActiveUser.GetInstance();
            _logger = new TextLog("BLI_Training", "Training_MAE_Data");
        }
        public void Run()
        {
            for(int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    foreach (var activeUser in _dataHolder.TrainingUsers)
                    {
                        _setConfigs(i,j);
                        _splitActiveUserRating(activeUser);

                        var bli = new BLI_Algorithm();
                        bli.CalculateUsersSimilarity_WithAU();
                        Individual ind = bli.RecommendedIndividual;
                        var criteria = new PrecisionCriterionParameters
                        {
                            MAE = new MAECalculator(ind).Compute(),
                            Precision = new PrecisionCalculator(ind).Compute(),
                            Recall = new RecallCalculator(ind).Compute()
                        };
                        double user_MAE = new MAECalculator(ind).Compute();
                        _LogResult(activeUser, criteria);
                    }
                }
            }
        }

        private void _splitActiveUserRating(User user)
        {
            int halfRatingSize = user.Ratings.Count() / 2;
            _AU.TrainingRatings = user.Ratings.Take(halfRatingSize).ToList();
            _AU.TestRatings = user.Ratings.Skip(halfRatingSize).ToList();

            _AU.UserId = user.UserId;
        }
        private void _setConfigs(int counterGenreTag , int counterSimilarities)
        {
            var config = Configs.GetInstance();

            config.ConfigValues.ImportanceDegree_Fitness["Importance degree of Genre"] = 
                (double)counterGenreTag / 10;
            config.ConfigValues.ImportanceDegree_Fitness["Importance degree of Tag"] =
                (double)(10 - counterGenreTag) / 10;

            config.ConfigValues.ImportanceDegree_Fitness["Importance degree of Users Similarity"] =
                (double)counterSimilarities / 10;
            config.ConfigValues.ImportanceDegree_Fitness["Importance degree of Semantic Correlation"] =
                (double)(10 - counterSimilarities) / 10;

            config.ConfigValues.IndividualListSize = 10;
        }
        private void _LogResult(User AU , PrecisionCriterionParameters criteria)
        {
            string logText = string.Format("UserID : {1}{0}RatingSize : {2}{0}" +
                "MAE : {3}{0}Precision : {4}{0}Recall : {5}{0}F1-Measure : {6}{0}",
                Environment.NewLine , AU.UserId , AU.Ratings.Count() ,
                criteria.MAE , criteria.Precision , criteria.Recall , criteria.F1_Measure);

            _logger.AddLog(logText);
        }
    }
}
