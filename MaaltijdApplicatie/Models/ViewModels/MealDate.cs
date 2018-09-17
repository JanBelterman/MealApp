﻿using MaaltijdApplicatie.Models.Domain;
using System;

namespace MaaltijdApplicatie.Models.ViewModels {

    public class MealDate {

        public DateTime Date { get; set; }
        public string MonthString { get; set; }
        public string DayOfWeekString { get; set; }

        public Meal Meal { get; set; }

        public bool UserIsRegistered { get; set; }

        public bool UserIsCook { get; set; }

        public bool MealIsFull { get; set; }

    }

}
