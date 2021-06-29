// ConAppCPlus.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
using namespace std;
struct node
{
	int data;
	struct node* next;
};

void sortedInsert(struct node** head_ref, int data);
struct node *newNode(int new_data)
{
	struct node* new_node = (struct node*) malloc(sizeof(struct node));
	new_node->data = new_data;
	new_node->next = NULL;
	return new_node;
}

void append(struct node** headRef, int newData)
{
	struct node* new_node = (struct node*) malloc(sizeof(struct node));
	struct node *last = *headRef;
	new_node->data = newData;
	new_node->next = NULL;
	if (*headRef == NULL)
	{
		*headRef = new_node;
		return;
	}
	while (last->next != NULL)last = last->next;
	last->next = new_node;
}

void bubbleSort(struct node *head)
{
	struct node* curr = head;
	int temp = -1;
	int current = -1;
	int next = -1;
	//struct node* temp = NULL;
	struct node* nextNode = NULL;
	struct node* last = NULL;

	while (curr->next != NULL)
	{
		nextNode = curr->next;

		if (curr->data >= nextNode->data)
		{
			temp = curr->data;
			curr->data = nextNode->data;
			nextNode->data = temp;

			if(last == NULL)
				last = curr->next;
		}

		curr = curr->next;
	}

	if (last != NULL)
		bubbleSort(last);
}

void printList(struct node *head)
{
	struct node *temp = head;
	while (temp != NULL)
	{
		cout << temp->data << ' ';
		temp = temp->next;
	}
	cout << endl;
}
/* Drier program to test count function*/
int main()
{
	int test;
	cin >> test;
	while (test--)
	{
		struct node* head = NULL;
		int n, k;
		cin >> n;
		for (int i = 0; i < n; i++) {
			cin >> k;
			append(&head, k);
		}

		bubbleSort(head);
		
		printList(head);
		cin >> k;
		sortedInsert(&head, k);
		printList(head);
	}
	return 0;
}

/*Please note that it's Function problem i.e.
you need to write your solution in the form of Function(s) only.
Driver Code to call/invoke your function is mentioned above.*/

/*
structure of the node of the list is as
struct node
{
	int data;
	struct node* next;
};
*/
void sortedInsert(struct node** head_ref, int data)
{
	// Code here
	// create a new node
	// put data into the node for int data
	// go through all of the nodes and 
	//  if there are no nodes, put this in as head node.  You are done
		// if there is >1
	node *last = (*head_ref)->next;

	struct node *temp = new struct node;
	temp->data = data;
	temp->next = NULL;

	struct node *curr = (*head_ref);
	struct node *prev = NULL;

	while (curr != NULL && data >= curr->data)
	{
		prev = curr;
		curr = curr->next;
	}

	if (prev == NULL)
	{
		temp->next = (*head_ref);
		(*head_ref) = temp;
		return;
	}
	prev->next = temp;
	temp->next = curr;
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
