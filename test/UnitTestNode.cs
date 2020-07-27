using CopyLinkedListShared;
using FluentAssertions;
using Xunit;

namespace CopyLinkedListTest
{
    /// <summary>
    /// Unit tests for the <see cref="Node"/> class.
    /// </summary>
    public class UnitTestNode
    {
        /// <summary>
        /// Ensure that the class can be instantiated successfully
        /// </summary>
        [Fact]
        public void NodeConstructsCorrectly()
        {
            new Node().Should().NotBeNull();
        }

        /// <summary>
        /// Ensure that the tag can be successfully set and then read back
        /// </summary>
        [Fact]
        public void SetTag()
        {
            Node node = new Node();
            node.SetTag(Consts.c_rootTag);

            node.GetTag().Should().Be(Consts.c_rootTag);
        }

        /// <summary>
        /// Ensure that the Next Node can be successfully set and then read back
        /// </summary>
        [Fact]
        public void SetNextNodeValid()
        {
            Node root = new Node();
            Node next = new Node();
            root.SetNext(next);

            root.GetNext().Should().Be(next);
        }

        /// <summary>
        /// Ensure that the Next Node can be successfully set to null and then read back
        /// </summary>
        [Fact]
        public void SetNextNodeNull()
        {
            Node root = new Node();
            root.SetNext(null);

            root.GetNext().Should().BeNull();
        }

        /// <summary>
        /// Ensure that the Reference Node can be successfully set and then read back
        /// </summary>
        [Fact]
        public void SetReferenceNodeValid()
        {
            Node root = new Node();
            Node refNode = new Node();
            root.SetReference(refNode);

            root.GetReference().Should().Be(refNode);
        }

        /// <summary>
        /// Ensure that the Reference Node can be successfully set to null and then read back
        /// </summary>
        [Fact]
        public void SetReferenceNodeNull()
        {
            Node root = new Node();
            root.SetReference(null);

            root.GetReference().Should().Be(null);
        }

        /// <summary>
        /// Ensure that a single node linked list with a null reference is valid
        /// </summary>
        [Fact]
        public void SingleNodeCaseNullReference()
        {
            Node rootNode = Helpers.CreateRandomList(1);
            rootNode.SetReference(null);

            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }

        /// <summary>
        /// Ensure that multiple node linked list with a null reference is valid
        /// </summary>
        [Fact]
        public void TwoNodeCaseNullReference()
        {
            Node rootNode = Helpers.CreateRandomList(2);
            rootNode.SetReference(null);

            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }

        /// <summary>
        /// Main copy case test.
        /// </summary>
        /// <param name="length">Length of the linked list that you want to test</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(1024)]
        [InlineData(1000000)]
        public void CopyCases(int length)
        {
            Node rootNode = Helpers.CreateRandomList(length);

            Node dupNode = Node.DuplicateList(rootNode);

            Helpers.AreListsIdentical(rootNode, dupNode).Should().BeTrue();
        }
    }
}
