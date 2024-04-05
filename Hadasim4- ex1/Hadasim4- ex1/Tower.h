#pragma once
#include <iostream>
using namespace std;
class Tower
{
private:
	int height;
	int width;
public:
	Tower();
	Tower(double height, double width);
	int getHeight();
	int getWidth();
	friend istream& operator>>(istream& in, Tower& temp);
};

