using System;
using System.Collections.Generic;
using System.Linq;
using Bronsysteem;
using NUnit.Framework;

namespace EtlTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //arrange
            var input = "Geschiedenis:Eindhoven,Duits:EtenLeur,Fysica:Helmond";

            //act
            var actual = input.Split(',')
                .Select(lessonString => lessonString.Split(':'))
                .Select(lessonArray => new Lesson(lessonArray[0], Enum.Parse<Locatie>(lessonArray[1])));

            //assert
            CollectionAssert.AreEqual(
                new List<Lesson>()
                {
                    new Lesson(
                        "Geschiedenis",
                        Locatie.Eindhoven
                    ),
                    new Lesson(
                        "Duits",
                        Locatie.EtenLeur
                    ),
                    new Lesson(
                        "Fysica",
                        Locatie.Helmond
                    )
                },
                actual
            );
        }
    }
}
