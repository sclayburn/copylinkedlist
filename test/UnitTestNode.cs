using System;
using Xunit;
using FluentAssertions;
using copylinkedlistshared;

namespace copylinkedlisttest
{
    public class UnitTestNode
    {
        [Fact]
        public void NodeConstructsCorrectly()
        {
            Node node = new Node();

            node.Should().NotBeNull();
        }

        [Fact]
        public void SetTag()
        {
            Node node = new Node();
            node.SetTag(Consts.c_RootTag);

            node.GetTag().Should().Be(Consts.c_RootTag);
        }

        [Fact]
        public void SingleNodeCaseNullReference()
        {
            Node rootNode = Helpers.CreateRandomList(1);
            rootNode.SetReference(null);
            
            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }

        [Fact]
        public void TwoNodeCaseNullReference()
        {
            Node rootNode = Helpers.CreateRandomList(2);
            rootNode.SetReference(null);

            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(1024)]
        public void CopyCases(int length)
        {
            Node rootNode = Helpers.CreateRandomList(length);

            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }
    }
}
