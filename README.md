# GenericCollectionsExtension

[![](https://img.shields.io/badge/.NET%20Standard-2.0-red)](https://github.com/Ts-Pytham/GenericCollectionsExtension)
[![](https://img.shields.io/badge/License-MIT-green)](ttps://github.com/Ts-Pytham/GenericCollectionsExtension/blob/master/LICENSE.txt)
[![PayPal-donate-button](https://img.shields.io/badge/paypal-donate-orange)](https://paypal.me/johansanchezdl?locale.x=es_XC)

**Generic Collections Extension** is a class library and  an extension of the data structures in .NET that adds new data structures such as binary search trees, stacks, queues, and a new type of list. 
These data structures can be used to store and organize data efficiently in .NET applications. Therefore, it is an extension of the data structures of the System.Collections.Generic library.

<h2>Data structure</h2>
New data structures were added that are derived from the traditional data structures, these are:

* Deque.
* PriorityQueue.
* PriorityStack.
* Binary Search Tree.
* SortedList.

<h3>Queue</h3>

A queue is a data structure that stores and retrieves items in a first-in-first-out (FIFO) manner. 
This means that the first item that is added to the queue is also the first item that is removed from the queue. 
Queues are useful for storing and managing data in applications where items need to be processed in the order in which they are received. 
For example, a queue could be used to hold tasks that need to be executed in the order in which they are received, or to hold messages that need to be sent in the order in which they were received.

<h4>Queue Type:</h4>

* Deque: Is a double-ended queue, which is a type of data structure that allows items to be added and removed from either end of the queue. 
This means that items can be added to the front or back of the queue, and can also be removed from the front or back of the queue.

* Priority Queue: Is a data structure in which each item has a priority associated with it, and items are stored and retrieved in order of their priority. 
This means that when items are added to the queue, they are automatically placed in the correct position based on their priority, and when items are removed from the queue, the item with the highest priority is always selected first.

<h3>Stack</h3>

A stack is a data structure that stores and retrieves items in a last-in-first-out (LIFO) manner. 
This means that the last item that is added to the stack is also the first item that is removed from the stack. 
Stacks are useful for storing and managing data in applications where items need to be processed in the reverse order in which they are received.

* Priority Stack: Is a type of data structure that combines the characteristics of a stack and a priority queue. 
Like a stack, a priority stack stores and retrieves items in a last-in-first-out (LIFO) manner, but also allows items to be added and removed based on their priority. 
This means that items can be added to the top of the stack in any order, but when items are removed from the stack, the item with the highest priority is always selected first. 

