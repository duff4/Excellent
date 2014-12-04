using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Resources;
using App2.Entities;

namespace App2.Extensions
{
    public static class LocalizationExtension
    {
        public static readonly ResourceLoader GlobalResourceLoader = new ResourceLoader(GenericRepo<Language>.GetFirst().SelectedCultureString);

        public static string Localize(this string stringToLocalize)
        {
            switch (stringToLocalize)
            {
                case "None": return GlobalResourceLoader.GetString("NoneEvaluationTypeString");
                case "Test": return GlobalResourceLoader.GetString("TestEvaluationTypeString");
                case "Exam": return GlobalResourceLoader.GetString("ExamEvaluationTypeString");

                case "Low": return GlobalResourceLoader.GetString("LowPriorityString");
                case "Normal": return GlobalResourceLoader.GetString("NormalPriorityString");
                case "High": return GlobalResourceLoader.GetString("HighPriorityString");

                case "Easy": return GlobalResourceLoader.GetString("EasyDifficultyString");
                case "Medium": return GlobalResourceLoader.GetString("MediumDifficultyString");
                case "Hard": return GlobalResourceLoader.GetString("HardDifficultyString");

                default : return stringToLocalize;
            }
        }
    }
}
