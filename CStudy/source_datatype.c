#include <stdio.h>

void draw(int i)
{
	// 1byte = 8bit
	i *= 8;
	while (i--)
	{
		printf("бр");
	}
	printf("\n");
}

int main()
{
	//data type bit test
	char c = NULL;
	printf("char: %d\n", sizeof(c));
	draw(sizeof(c));

	short s = 0;
	printf("short: %d\n", sizeof(s));
	draw(sizeof(s));

	int i = 0;
	printf("int: %d\n", sizeof(i));
	draw(sizeof(i));

	long l = 0;
	printf("long: %d\n", sizeof(l));
	draw(sizeof(l));

	float f = 0;
	printf("float: %d\n", sizeof(f));
	draw(sizeof(f));

	double d = 0;
	printf("double: %d\n", sizeof(d));
	draw(sizeof(d));
}