#include <iostream>
#include "Tower.h"

using namespace std;

void rectangularTower() {
    Tower t;
    cout << "Enter height and width of the rectangular tower: ";
    cin >> t;

    if (t.getWidth() - t.getHeight() > 5) {
        cout << "Area of the rectangular tower: " << t.getHeight() * t.getWidth() << endl;
    }
    else {
        cout << "Perimeter of the rectangular tower: " << 2 * (t.getHeight() + t.getWidth()) << endl;
    }
}
void printTriangle(Tower t)
{
    int rest = 0, repet = 0;
    if (t.getWidth() % 2 == 0 || t.getWidth() > 2 * t.getHeight()) {
        cout << "The triangle cannot be printed." << endl;
    }
    else {
        // Top of the triangle
        for (int i = 1;i < t.getWidth() / 2 + 1;i++)
            cout << " ";
        cout << "*";
        cout << endl;

        // Middle of the triangle
        if (t.getHeight() > t.getWidth())
        {
            repet = (t.getHeight() - 2) / ((t.getWidth() - 2) / 2);
            if ((t.getHeight() - 2) % ((t.getWidth() - 2) / 2) != 0)
            {
                rest = (t.getHeight() - 2) % ((t.getWidth() - 2) / 2);
            }
        }
        else
        {
            repet = (t.getHeight() - 2) / ((t.getWidth() - 2) / 2);
            if (((t.getWidth() - 2) / 2) % (t.getWidth() - 2) != 0)
            {
                rest = (t.getHeight() - 2) % ((t.getWidth() - 2) / 2);
            }
        }
        int middle_row = (t.getWidth() - 1) / 2 + 1;
        int num_stars = 3;
        for (int row = 0; row <= middle_row, num_stars < t.getWidth(); row++) {
            int num_spaces = (t.getWidth() - num_stars) / 2;
            if (row == 0)
                repet += rest;
            for (int i = 0; i < repet; i++)
            {
                for (int i = 0; i < num_spaces; i++) {
                    cout << " ";
                }
                for (int i = 0; i < num_stars; i++) {
                    cout << "*";
                }
                cout << endl;
            }
            num_stars += 2;
            if (row == 0)
                repet -= rest;
        }
        // Bottom of the triangle
        for (int i = 0;i < t.getWidth();i++)
        {
            cout << "*";
        }
        cout << endl;

    }
}
void triangularTower() {
    Tower t;
    cout << "Enter height and width of the triangular tower: ";
    cin >> t;

    int perimeter = 2 * t.getHeight() + t.getWidth();

    int option;
    cout << "Choose an option:" << endl;
    cout << "1. Calculation of the perimeter of the triangle" << endl;
    cout << "2. Printing the triangle" << endl;
    cin >> option;

    switch (option) {
    case 1:
        cout << "Perimeter of the triangular tower: " << perimeter << endl;
        break;
    case 2:
        printTriangle(t);
        break;
    default:
        cout << "Invalid option!" << endl;
    }
}



int main() {
    int choice;
    do {
        cout << "Main Menu:" << endl;
        cout << "1. Rectangular Tower" << endl;
        cout << "2. Triangular Tower" << endl;
        cout << "3. Exit" << endl;
        cout << "Enter your choice: ";
        cin >> choice;

        switch (choice) {
        case 1:
            rectangularTower();
            break;
        case 2:
            triangularTower();
            break;
        case 3:
            cout << "Exiting program. Goodbye!" << endl;
            break;
        default:
            cout << "Invalid choice. Please try again." << endl;
        }
    } while (choice != 3);

    return 0;
}
