using System;

namespace AssetGuard.Core.Entities
{
    public class PredictiveModel : BaseEntity
    {
        public string Name { get; set; }
        public string ModelType { get; set; }
        public string Version { get; set; }
        public string TrainingDatasetUrl { get; set; }
        public double AccuracyScore { get; set; }
        public DateTime TrainedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class MaintenancePrediction : BaseEntity
    {
        public int AssetId { get; set; }
        public int ModelId { get; set; }
        public DateTime PredictionDate { get; set; } = DateTime.UtcNow;
        public DateTime PredictedFailureDate { get; set; }
        public double ConfidenceScore { get; set; }
        public string RecommendedAction { get; set; }
        public string ContributingFactors { get; set; }
    }

    public class FailureMode : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int AssetCategoryId { get; set; }
        public string Severity { get; set; }
        public double MtbfHours { get; set; }
    }
}
