using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using ToyRobotApp.Models;
using ToyRobotApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToyRobotTests
{
    /// <summary>
    /// This test file contans all the tests related to ToyRobotService.cs
    /// </summary>
    public class ToyRobotServiceTests
    {
        ToyRobotService toyService = new ToyRobotService();

        Robot robot = new Robot()
        {
            XAxis = 0,
            YAxis = 0,
            DirectionRobotFacing = "NORTH"
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProcessCommands_Should_Return_NewPlacementResult_Object_With_Successful_Values()
        {
            //Arrange
            List<string> listOfCommands = new List<string>()
            {
                {"PLACE, 1,1,EAST" },
                {"MOVE"},
                {"RIGHT" }
            };

            var expectedResult = new Robot { XAxis = 2, YAxis = 1, DirectionRobotFacing = "SOUTH" };

            //Act
            var result = toyService.ProcessCommands(robot,listOfCommands);

            //Assert
            result.Should().BeOfType<NewPlacementResult>();
            result.Success.Should().BeTrue();
            result.CurrentPosition.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ProcessCommands_Will_Not_Proccess_MOVE_If_It_Leads_Robot_Out_Of_Bounds()
        {
            //Arrange
            List<string> listOfCommands = new List<string>()
            {
                {"PLACE, 4,0,EAST" },
                {"MOVE"},
                {"LEFT" }
            };

            var expectedResult = new Robot { XAxis = 4, YAxis = 0, DirectionRobotFacing = "NORTH" };

            //Act
            var result = toyService.ProcessCommands(robot, listOfCommands);

            //Assert
            result.Should().BeOfType<NewPlacementResult>();
            result.Success.Should().BeTrue();
            result.CurrentPosition.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ProcessCommands_Will_Proccess_LEFT_Successfully()
        {
            //Arrange
            List<string> listOfCommands = new List<string>()
            {
                {"PLACE, 1,2,NORTH" },
                {"MOVE" },
                {"LEFT" },
                {"LEFT" }
            };

            var expectedResult = new Robot { XAxis = 1, YAxis = 3, DirectionRobotFacing = "SOUTH" };

            //Act
            var result = toyService.ProcessCommands(robot, listOfCommands);

            //Assert
            result.Should().BeOfType<NewPlacementResult>();
            result.Success.Should().BeTrue();
            result.CurrentPosition.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void ProcessCommands_Will_Proccess_RIGHT_Successfully()
        {
            //Arrange
            List<string> listOfCommands = new List<string>()
            {
                {"PLACE, 1,2,NORTH" },
                {"MOVE" },
                {"RIGHT" },
                {"RIGHT" }
            };

            var expectedResult = new Robot { XAxis = 1, YAxis = 3, DirectionRobotFacing = "SOUTH" };

            //Act
            var result = toyService.ProcessCommands(robot, listOfCommands);

            //Assert
            result.Should().BeOfType<NewPlacementResult>();
            result.Success.Should().BeTrue();
            result.CurrentPosition.Should().BeEquivalentTo(expectedResult);
        }
    }
}