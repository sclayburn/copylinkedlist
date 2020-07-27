namespace CopyLinkedListShared
{
    /// <summary>
    /// <see cref="Node"/> implementation.  Implements the singly linked list with references and the static duplicate function.
    /// </summary>
    public class Node
    {
        Node next;
        string tag;
        Node reference;

        public Node()
        {
        }

        /// <summary>
        /// Set the tag for the node.
        /// </summary>
        /// <param name="tag">New tag value.</param>
        public void SetTag(string tag)
        {
            this.tag = tag;
        }

        /// <summary>
        /// Get the tag for the node.
        /// </summary>
        /// <returns>The string value, null if not set.</returns>
        public string GetTag() => this.tag;

        /// <summary>
        /// Set the next node in the singly linked list.
        /// </summary>
        /// <param name="next">Next node in the list.  Null to represent the end of the list.</param>
        public void SetNext(Node next)
        {
            this.next = next;
        }

        /// <summary>
        /// Get the next node in the singly linked list.
        /// </summary>
        /// <returns>Next node.  Null is returned if this is the end of the list.</returns>
        public Node GetNext() => this.next;

        /// <summary>
        /// Set the reference node in the singly linked list.
        /// </summary>
        /// <param name="reference">Node to reference in the list.  Null for no reference.</param>
        public void SetReference(Node reference)
        {
            this.reference = reference;
        }

        /// <summary>
        /// Get the reference node.
        /// </summary>
        /// <returns>The reference node.  Null is returned if this node does not contain a reference node.</returns>
        public Node GetReference() => this.reference;

        /// <summary>
        /// Create an exact duplicate of the supplied singly linked list in O(n) time and O(1) space.
        /// </summary>
        /// <param name="list">Singly linked list to duplicate.</param>
        /// <returns>A duplicate of list, with zero dependence on any of the nodes in list.</returns>
        public static Node DuplicateList(Node list)
        {
            Node currentNode = list;

            // Insert new nodes interleaved with existing nodes
            while (currentNode != null)
            {
                Node holdNext = currentNode.next;

                Node newNode = new Node();
                newNode.SetTag(currentNode.GetTag());
                currentNode.next = newNode;
                currentNode.next.next = holdNext;
                currentNode = holdNext;
            }
            currentNode = list;

            // Set the reference pointers of the new nodes
            while (currentNode != null)
            {
                if (currentNode.next != null)
                {
                    if (currentNode.reference != null)
                    {
                        currentNode.next.reference = currentNode.reference.next;
                    }
                    else
                    {
                        currentNode.next.reference = null;
                    }
                }

                if (currentNode.next != null)
                {
                    currentNode = currentNode.next.next;
                }
                else
                {
                    currentNode = null;
                }
            }

            Node currentListOne = list;
            Node currentListTwo = list.next;
            Node startOfListTwo = currentListTwo;

            // Pull the two lists apart
            while (currentListOne != null && currentListTwo != null)
            {
                if (currentListOne.next != null)
                {
                    currentListOne.next = currentListOne.next.next;
                }

                if (currentListTwo.next != null)
                {
                    currentListTwo.next = currentListTwo.next.next;
                }

                currentListOne = currentListOne.next;
                currentListTwo = currentListTwo.next;
            }

            return startOfListTwo;
        }
    }
}
