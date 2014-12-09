/*
 * Excellent - Student Organizer
 * Copyright (c ) 2014, Alexander Davydov, All rights reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

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
