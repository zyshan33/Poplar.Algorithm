// See https://aka.ms/new-console-template for more information


using Poplar.Algorithm.LinkedListQuestion;

var a = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));

var b = new ListNode(1, new ListNode(2, null));

//var reverse = new ReverseLinkedList().ReverseListThree(a);

//var swapParis = new SwapPairs().SwapPairsThree(a);

var reverseK = new ReverseNodesInKGroup().ReverseKGroupTwo(a, 2);

Console.WriteLine("Hello, World!");
