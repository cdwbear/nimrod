// CppDeleteWithoutHeadPointer.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
//#include <bits/stdc++.h>
#include <iostream>
using namespace std;

//int main()
//{
//    std::cout << "Hello World!\n"; 
//}

/*

{
#include<bits/stdc++.h>
using namespace std;
/* Link list node */
struct Node
{
	int data;
	Node* next;
}*head;
Node *findNode(Node* head, int search_for)
{
	Node* current = head;
	while (current != NULL)
	{
		if (current->data == search_for)
			break;
		current = current->next;
	}
	return current;
}
void insert()
{
	int n, i, value;
	Node *temp = (Node *)malloc(sizeof(Node));
	scanf_s("%d", &n);
	for (i = 0; i < n; i++)
	{
		scanf_s("%d", &value);
		if (i == 0)
		{
			head = (Node *)malloc(sizeof(Node));
			head->data = value;
			head->next = NULL;
			temp = head;
			continue;
		}
		else
		{
			temp->next = (Node *)malloc(sizeof(Node));
			temp = temp->next;
			temp->data = value;
			temp->next = NULL;
		}
	}
}
/* Function to print linked list */
void printList(Node *node)
{
	while (node != NULL)
	{
		printf("%d ", node->data);
		node = node->next;
	}
	//printf("		");
}

void deleteNode(Node *node_ptr);

/* Drier program to test above function*/
int main(void)
{
	/* Start with the empty list */
	int t, k, n, value;
	/* Created Linked list is 1->2->3->4->5->6->7->8->9 */
	scanf_s("%d", &t);
	while (t--)
	{
		insert();
		scanf_s("%d", &k);
		Node *del = findNode(head, k);
		if (del != NULL && del->next != NULL)
		{
			deleteNode(del);
		}
		printList(head);
	}
	return(0);
}


void deleteNode(Node *node_ptr)
{
	while (node_ptr->next != NULL)
	{
		node_ptr->data = node_ptr->next->data;
		struct Node* temp = node_ptr;
		node_ptr = node_ptr->next;
		delete temp;
	}
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
