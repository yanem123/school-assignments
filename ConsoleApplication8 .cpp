#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;


typedef struct item {
    int value;
    struct item* next;
}ITEM;

ITEM* insert_and_delete(ITEM* head, int sw) {
    if (sw==0)
    {
        if (head == NULL)
        {
            head = new ITEM;
            head->value = rand() % 10;
            head->next = NULL;
        }
        else
        {
            ITEM* act = head;
            while (act->next != NULL)
            {
                act = act->next;
            }
            act->next = new ITEM;
            act = act->next;
            act->value = rand() % 10;
            act->next = NULL;
            
        }
    }
    else if (sw == 1) {
        if (head==NULL)
        {
            cout << "A lista ures" << endl;
            return NULL;
        }
        if (head->next==NULL)
        {
            delete head;
            return NULL;
        }
        ITEM* act = head;
        while (1)
        {
            ITEM* tmp = act->next;
            if (tmp->next==NULL) {
                delete act->next;
                act->next = NULL;
                return head;
            }
            act = act->next;
        }
    }
    else {
        cout << "Nem definiált opció" << endl;
    }


    return head;
}

void print_list(ITEM* head) {
    ITEM* i = head;
    for (; i->next != NULL; i=i->next)
    {
        cout << "Element: " << i->value << endl;
    }
    cout << "Element: " << i->value << endl;
}

int main()
{
    srand((unsigned)time(NULL));
    ITEM* head = NULL;
    head = insert_and_delete(head, 0);
    head = insert_and_delete(head, 0);
    print_list(head);
    head = insert_and_delete(head, 1);
    cout << "Torles utan" << endl;
    print_list(head);

    return 0;
}
