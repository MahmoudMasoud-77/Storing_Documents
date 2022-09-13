
using System.ComponentModel.DataAnnotations;

namespace Storing_Documents.Data.Enams
{
    public enum TypeOfPriority
    {
        [Display(Name = "Low")]
        Low,
        [Display(Name = "High")]
        High,
        [Display(Name = "Critical")]
        Critical
    }

    //public static class TypeOfPriority
    //{
    //    public const string Low = "Low";
    //    public const string High = "High";
    //    public const string Critical = "Critical";
    //}
}