﻿using MaaltijdApplicatie.Models.Domain;
using MaaltijdApplicatie.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaaltijdApplicatie.Models.Logic {

    // Transforms meals, so that all dates are added to the list for the coming 2 weeks and dates are filled with available meals
    public class MealTransformer {

        public static IEnumerable<MealDate> TransformMeals(IEnumerable<Meal> meals, AppUser student) {

            // Create list
            List<MealDate> mealDates = new List<MealDate>();

            // Get all dates for coming 2 weeks
            // Insert meals in correct dates
            foreach (var d in DateTime.Now.GetDatesForComingTwoWeeks()) {

                var meal = meals.FirstOrDefault(m => m.DateTime.Date == d.Date);

                var mealDate = new MealDate() {
                    Date = d,
                    MonthString = d.ToString("MMMM"),
                    DayOfWeekString = UppercaseFirst(d.ToString("dddd")),
                    Meal = meal, // Insert meal or set null
                    UserIsRegistered = CheckIfUserIsRegistered(meal, student)
                };

                mealDates.Add(mealDate);

            }

            // Return list
            return mealDates;

        }

        public static void AddDateStrings(MealDate mealDate) {

            mealDate.DayOfWeekString = UppercaseFirst(mealDate.Date.ToString("dddd"));
            mealDate.MonthString = mealDate.Date.ToString("MMMM");

        }

        static bool CheckIfUserIsRegistered(Meal meal, AppUser student) { // Change to lambda

            if (meal != null) {

                foreach (MealStudent mealStud in meal.StudentsGuests) {
                    if (mealStud?.AppUser?.Id == student?.Id) {
                        return true;
                    }
                }

            }

            return false;

        }

        static string UppercaseFirst(string s) {

            // Check for empty string.
            if (string.IsNullOrEmpty(s)) {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);

        }

    }

}
