#include "Tower.h"
#include <iostream>
using namespace std;
Tower::Tower()
{
	height = 0;
	width = 0;
}
Tower::Tower(double height, double width)
{
}

int Tower::getHeight()
{
	return height;
}

int Tower::getWidth()
{
	return width;
}

istream& operator>>(istream& in, Tower& temp)
{
	in >> temp.height >> temp.width;
	return in;
}
