using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace copylinkedlistshared
{ 
	public static class Helpers
	{
		public static Node CreateRootNode(ref int currentTag)
		{
			Node root = new Node();
			root.SetTag(currentTag.ToString());
			currentTag++;

			return root;
		}

		public static Node CreateNextNode(Node parent, ref int currentTag)
		{
			Node child = new Node();
			child.SetTag(currentTag.ToString());
			parent.SetNext(child);
			currentTag++;

			return child;
		}

		public static Node CreateRandomList(int maxDepth)
		{
			int currentTag = 1;
			int currentDepth = 1;
			Node parent = null;
			List<Node> referenceCache = new List<Node>();

			Node root = CreateRootNode(ref currentTag);
			referenceCache.Add(root);
			parent = root;

			// Create new nodes to maxDepth
			while(currentDepth < maxDepth)
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

		public static bool AreListsIdentical(Node listOne, Node listTwo)
        {
			Node curNodeListOne = listOne;
			Node curNodeListTwo = listTwo;
			while (curNodeListOne != null)
            {
				string tagOne = string.Empty;
				Node referenceListOne = curNodeListOne.GetReference();
				if (referenceListOne != null)
                {
					tagOne = referenceListOne.GetTag();
                }
				string tagTwo = string.Empty;
				Node referenceListTwo = curNodeListTwo.GetReference();
				if (referenceListTwo != null)
				{
					tagTwo = referenceListTwo.GetTag();
				}

				if (string.Compare(tagOne, tagTwo, false) != 0)
                {
					return false;
                }

				curNodeListOne = curNodeListOne.GetNext();
				curNodeListTwo = curNodeListTwo.GetNext();
			}

			return true;
        }

		public static void PrintLists(Node listOne, Node listTwo)
        {
			PrintList(Consts.c_ListOneLabel, listOne);
			PrintList(Consts.c_ListTwoLabel, listTwo);
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
				Console.WriteLine($"Node Tag [ {currentNode.GetTag(), 4} ] / Hash [ {currentNode.GetHashCode(), 10} ] -- Node Ref Tag [ {refTag, 4} ] / Hash [ {refHashCode, 10} ]");
				currentNode = currentNode.GetNext();
            }
        }
	}
}
