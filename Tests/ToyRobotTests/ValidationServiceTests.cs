using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToyRobotApp.Constants.Exceptions;
using ToyRobotApp.Services;

namespace ToyRobotTests
{
    /// <summary>
    /// This test file contans all the tests related to Validation.cs
    /// </summary>
    public class ValidationServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateIfConsoleInputIsInteger_Should_Throw_Error()
        {
            //Arrange
            List<string> incorrectValues = new List<string>()
            {
                "",
                "2e",
                "d3",
                "!"
            };

            var result = new Exception();

            //Act
            try
            {
                foreach (string item in incorrectValues)
                {
                    ValidationService.ValidateIfConsoleInputIsInteger(item);
                }
            }
            catch (Exception e)
            {
                result = e;
            }

            //Assert
            result.Should().BeOfType<ValueNotValidException>();
        }

        [Test]
        public void ValidateIfConsoleInputIsInteger_Should_Return_Successful_Result()
        {
            //Arrange

            var num = "1";

            //Act
            var result = ValidationService.ValidateIfConsoleInputIsInteger(num);

            //Assert
            result.Should().Be(1);
        }

        [Test]
        public void ValidateIfMoveIsWithinBounds_Should_Throw_Error()
        {
            //Arrange
            Dictionary<string,int> outsideBounds1 = new Dictionary<string, int>()
            {
                {"x",5 },
                {"y",-1}
            };
            Dictionary<string, int> outsideBounds2 = new Dictionary<string, int>()
            {
                {"x",1 },
                {"y",-1}
            };

            List<Dictionary<string, int>> outOfBoundsValues = new List<Dictionary<string, int>>()
            {
                outsideBounds1,
                outsideBounds2
            };


            var result = new Exception();

            //Act
            try
            {
                foreach (Dictionary<string,int> item in outOfBoundsValues)
                {
                    ValidationService.ValidateIfMoveIsWithinBounds(item);
                }
            }
            catch (Exception e)
            {
                result = e;
            }

            //Assert
            result.Should().BeOfType<RobotOutOfBoundsException>();
        }

        [Test]
        public void ValidateIfMoveIsWithinBounds_Should_Return_True()
        {
            //Arrange
            Dictionary<string, int> correctValues = new Dictionary<string, int>()
            {
                {"x",4 },
                {"y",0}
            };


            //Act
            var result = ValidationService.ValidateIfMoveIsWithinBounds(correctValues);

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void ValidateFirstCommandIsPlace_Should_Throw_Error()
        {
            //Arrange
            var firstCommandIsPlace = false;
            var result = new Exception();
            //Act
            try
            {
                ValidationService.ValidateFirstCommandIsPlace(firstCommandIsPlace);
            }
            catch (Exception e)
            {
                result = e;
            }

            //Assert
            result.Should().BeOfType<InvalidFirstCommandException>();
        }

        [Test]
        public void ValidateFirstCommandIsPlace_Should_Return_True()
        {
            //Arrange
            var correctValue = true;

            //Act
            var result = ValidationService.ValidateFirstCommandIsPlace(correctValue);

            //Assert
            result.Should().Be(true);
        }
    }
}