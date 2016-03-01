namespace Euler.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using FluentAssertions;

    public class EulerTests
    {
        [Fact]
        public void RunWithDefaultParameters()
        {
            var euler = new Euler();

            var result = euler.FindEulerCycle(0);

            result.Should().BeEquivalentTo(new List<char> { 'A', 'B', 'C', 'D', 'E', 'C', 'A' });
        }

        [Fact]
        public void RunWithUserTypedParameters()
        {
            var graph = new int[7][];
            graph[0] = new int[7] { 0, 1, 1, 1, 0, 0, 1 };
            graph[1] = new int[7] { 1, 0, 1, 0, 1, 1, 0 };
            graph[2] = new int[7] { 1, 1, 0, 1, 1, 0, 0 };
            graph[3] = new int[7] { 1, 0, 1, 0, 1, 0, 1 };
            graph[4] = new int[7] { 0, 1, 1, 1, 0, 1, 0 };
            graph[5] = new int[7] { 0, 1, 0, 0, 1, 0, 0 };
            graph[6] = new int[7] { 1, 0, 0, 1, 0, 0, 0 };

            var euler = new Euler(graph);
            var result = euler.FindEulerCycle(0);

            result.Should().BeEquivalentTo(new List<char> { 'A', 'B', 'C', 'A', 'D', 'C', 'E', 'B', 'F', 'E', 'D', 'G', 'A' });
        }


        [Fact]
        public void GraphWhichDoesNotContainsOddNumberOfNeighboursShouldThrowInvalidArgumentException()
        {
            var graph = new int[5][];
            graph[0] = new int[5] { 0, 1, 1, 1, 1};
            graph[1] = new int[5] { 1, 0, 1, 0, 1 };
            graph[2] = new int[5] { 1, 1, 0, 1, 1 };
            graph[3] = new int[5] { 1, 0, 1, 0, 1 };
            graph[4] = new int[5] { 0, 1, 1, 1, 0 };
            Assert.Throws<ArgumentException>(() => new Euler(graph));
        }
    }
}
