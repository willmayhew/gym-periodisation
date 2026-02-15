using FluentAssertions;
using GymPeriodisation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymPeriodisation.Tests.Models
{
    public class ExerciseTests
    {
        [Theory]
        [InlineData("Bench Press", "benchpress")]
        [InlineData("bench-Press", "benchpress")]
        [InlineData(" BENCH   press!! ", "benchpress")]
        [InlineData("bench_press", "benchpress")]
        [InlineData("benchpress", "benchpress")]
        public void Normalize_Should_Remove_Punctuation_Spaces_And_Casing(string input, string expected)
        {
            var exercise = new Exercise
            {
                Name = input,
            };

            exercise.NormalizedName.Should().Be(expected);
        }

    }
}
