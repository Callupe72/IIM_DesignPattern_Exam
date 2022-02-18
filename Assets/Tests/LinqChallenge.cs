using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqChallenge
{
    Health CreateHealth(int maxHealth, int startHealth)
        => new GameObject("Health GameObject")
            .AddComponent<Health>()
            .SetField("_maxHealth", maxHealth)
            .SetField("_startHealth", startHealth)
            .CallAwake();


    [Test]
    public void Even()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42, 9000 };

        IEnumerable<int> even = values.Where(x => x % 2 == 0);

        // Act
        IEnumerable<int> Act()
        {
            return even;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == 12);
        Assert.True(queryResult[1] == 90);
        Assert.True(queryResult[2] == 22);
        Assert.True(queryResult[3] == 42);
        Assert.True(queryResult[4] == 9000);
    }

    [Test]
    public void EvenLess1000()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42, 9000, 998, 1002 };

        IEnumerable<int> evenLess1000 = values
            .Where(x => x % 2 == 0)
            .Where(x => x < 1000);


        // Act
        IEnumerable<int> Act()
        {
            return evenLess1000;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == 12);
        Assert.True(queryResult[1] == 90);
        Assert.True(queryResult[2] == 22);
        Assert.True(queryResult[3] == 42);
        Assert.True(queryResult[4] == 998);
    }

    [Test]
    public void Times2()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        IEnumerable<int> times2 = values.Select(x => x * 2);

        // Act
        IEnumerable<int> Act()
        {
            return times2;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == 24);
        Assert.True(queryResult[1] == 6);
        Assert.True(queryResult[2] == 180);
        Assert.True(queryResult[3] == 44);
        Assert.True(queryResult[4] == 84);
    }

    [Test]
    public void Times3Even()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        IEnumerable<int> time3EvenList = values
            .Where(x => x % 2 == 0)
            .Select(x => x * 3);


        // Act
        IEnumerable<int> Act()
        {
            return time3EvenList;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == 36);
        Assert.True(queryResult[1] == 270);
        Assert.True(queryResult[2] == 66);
        Assert.True(queryResult[3] == 126);
    }

    [Test]
    public void Order()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        IEnumerable<int> orderedList = values.OrderBy(i => i);

        // Act
        IEnumerable<int> Act()
        {
            return orderedList;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == 3);
        Assert.True(queryResult[1] == 12);
        Assert.True(queryResult[2] == 22);
        Assert.True(queryResult[3] == 42);
        Assert.True(queryResult[4] == 90);
    }

    [Test]
    public void OrderAndThenIsEven()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        IEnumerable<bool> orderAndThenIsEven = values
            .OrderBy(x => x)
            .Select(x => x % 2 == 0);

        // Act
        IEnumerable<bool> Act()
        {
            return orderAndThenIsEven;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == false);
        Assert.True(queryResult[1] == true);
        Assert.True(queryResult[2] == true);
        Assert.True(queryResult[3] == true);
        Assert.True(queryResult[3] == true);
    }

    [Test]
    public void TupleWithTimes2()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        IEnumerable<(int, int)> tuppleWithTime2 = values.Select(x=>(x, x*2));

        // Act
        IEnumerable<(int, int)> Act()
        {
            return tuppleWithTime2;
        }
        var queryResult = Act().ToList();

        // Assert 
        Assert.True(queryResult[0] == (12, 24));
        Assert.True(queryResult[1] == (3, 6));
        Assert.True(queryResult[2] == (90, 180));
        Assert.True(queryResult[3] == (22, 44));
        Assert.True(queryResult[4] == (42, 84));
    }

    [Test]
    public void Average()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        double average = values.Average();

        // Act
        double Act()
        {
            return average;
        }
        var queryResult = Act();

        // Assert 
        //Ici il fallait convertir le "33.8" en "33.8f" afin de cast le résultat en float
        Assert.IsTrue((float)queryResult == 33.8f);
    }

    [Test]
    public void Min()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        int min = values.Min();

        // Act
        int Act()
        {
            return min;
        }
        var queryResult = Act();

        // Assert 
        Assert.IsTrue(queryResult == 3);
    }

    [Test]
    public void Max()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        int max = values.Max();
        // Act
        int Act()
        {
            return max;
        }
        var queryResult = Act();

        // Assert 
        Assert.IsTrue(queryResult == 90);
    }

    [Test]
    public void Sum()
    {
        // Arrange 
        List<int> values = new List<int>() { 12, 3, 90, 22, 42 };

        int sum = values.Sum();

        // Act
        int Act()
        {
            return sum;
        }
        var queryResult = Act();

        // Assert 
        Assert.IsTrue(queryResult == 169);
    }

}