using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CopyLinkedListShared
{
    /// <summary>
    /// Generic & misc helper functions.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Create a singly linked list that is maxDepth deep and has randomly assigned reference nodes.
        /// </summary>
        /// <param name="maxDepth">The maximum depth that you want the linked list to be.  Must be greater than 0.</param>
        /// <returns>Root <see cref="Node"/> of the new linked list.</returns>
        public static Node CreateRandomList(int maxDepth)
        {
            if (maxDepth < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxDepth), Consts.c_argExceptionDescMaxDepth);
            }

            int currentTag = 1;
            int currentDepth = 1;
            Node parent = null;
            List<Node> referenceCache = new List<Node>();

            Node root = CreateRootNode(ref currentTag);
            referenceCache.Add(root);
            parent = root;

            // Create new nodes to maxDepth
            while (currentDepth < maxDepth)
            {
                Node next = CreateNextNode(parent, ref currentTag);
                referenceCache.Add(next);
                parent = next;
                currentDepth++;
            }

            parent = root;
            int upperBound = referenceCache.Count;
            // Traverse the list and assign random reference nodes
            while (parent != null)
            {
                int rndValue = RandomNumberGenerator.GetInt32(upperBound);
                Node refNode = referenceCache[rndValue];
                parent.SetReference(refNode);

                parent = parent.GetNext();
            }

            return root;
        }

        /// <summary>
        /// Takes two linked lists and ensures that their node tags and reference tags are identical.
        /// </summary>
        /// <param name="listOne">List to compare <see cref="listTwo"/> against.  Cannot be null.</param>
        /// <param name="listTwo">List that will be compare to <see cref="listOne"/>.  Cannot be null.</param>
        /// <returns>bool indicating whether the two lists tags were identical</returns>
        public static bool AreListsIdentical(Node listOne, Node listTwo)
        {
            if (listOne == null)
            {
                throw new ArgumentNullException(nameof(listOne));
            }
            if (listTwo == null)
            {
                throw new ArgumentNullException(nameof(listTwo));
            }

            Node curNodeListOne = listOne;
            Node curNodeListTwo = listTwo;
            while (curNodeListOne != null)
            {
                string tagOne = curNodeListOne.GetTag();
                string refTagOne = string.Empty;
                Node referenceListOne = curNodeListOne.GetReference();
                if (referenceListOne != null)
                {
                    refTagOne = referenceListOne.GetTag();
                }
                string tagTwo = curNodeListTwo.GetTag();
                string refTagTwo = string.Empty;
                Node referenceListTwo = curNodeListTwo.GetReference();
                if (referenceListTwo != null)
                {
                    refTagTwo = referenceListTwo.GetTag();
                }

                if (string.Compare(refTagOne, refTagTwo, false) != 0 || string.Compare(tagOne, tagTwo, false) != 0)
                {
                    return false;
                }

                curNodeListOne = curNodeListOne.GetNext();
                curNodeListTwo = curNodeListTwo.GetNext();
            }

            return true;
        }

        /// <summary>
        /// Visually print, in human readable format to stdout, each linked list
        /// </summary>
        /// <param name="listOne">First linked list to print.  Cannot be null.</param>
        /// <param name="listTwo">Second linked list to print.  Cannot be null.</param>
        public static void PrintLists(Node listOne, Node listTwo)
        {
            if (listOne == null)
            {
                throw new ArgumentNullException(nameof(listOne));
            }
            if (listTwo == null)
            {
                throw new ArgumentNullException(nameof(listTwo));
            }

            PrintList(Consts.c_listOneLabel, listOne);
            PrintList(Consts.c_listTwoLabel, listTwo);
        }

        private static Node CreateRootNode(ref int currentTag)
        {
            Node root = new Node();
            root.SetTag(currentTag.ToString());
            currentTag++;

            return root;
        }

        private static Node CreateNextNode(Node parent, ref int currentTag)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            Node child = new Node();
            child.SetTag(currentTag.ToString());
            parent.SetNext(child);
            currentTag++;

            return child;
        }

        private static void PrintList(string name, Node list)
        {
            Node currentNode = list;
            Console.WriteLine();
            Console.WriteLine($"List Name: [ {name} ]");
            while (currentNode != null)
            {
                Node referenceNode = currentNode.GetReference();
                string refTag = string.Empty;
                int refHashCode = -1;
                if (referenceNode != null)
                {
                    refTag = referenceNode.GetTag();
                    refHashCode = referenceNode.GetHashCode();
                }
                Console.WriteLine($"Node Tag [ {currentNode.GetTag(),4} ] / Hash [ {currentNode.GetHashCode(),10} ] -- Node Ref Tag [ {refTag,4} ] / Hash [ {refHashCode,10} ]");
                currentNode = currentNode.GetNext();
            }
        }
    }
}
