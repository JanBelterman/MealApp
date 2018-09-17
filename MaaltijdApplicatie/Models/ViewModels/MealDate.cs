﻿using MaaltijdApplicatie.Models.Domain;
using System;

namespace MaaltijdApplicatie.Models.ViewModels {

    public class MealDate {

        public DateTime Date { get; set; }
        public string MonthString { get; set; }
        public string DayOfWeekString { get; set; }

        public Meal Meal { get; set; }

        public bool UserIsRegistered { get; set; } = false;

        public bool UserIsCook { get; set; } = false;

        public bool MealIsFull { get; set; } = false;

        public bool UserLoggedIn { get; set; } = false;

    }

}
