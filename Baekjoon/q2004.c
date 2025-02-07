#include <stdio.h>

int nCr(int n, int r)
{
	int x = (n - r < r) ? r : n-r;
	int y = (n - r < r) ? n-r : r;

	int v2 = 0, v5 = 0;

	int a=0, b=0;
	for(int i=5; i<=n; i+=5)
	{
		if (i <= y)
		{
			int v = i;
			while(v%5==0)
			{
				a++; v /= 5;
			}
			
		}
		else if (i > x)
		{
			int v = i;
			while(v%5==0)
			{
				b++; v /= 5;
			}
		}
	}
	v5 = b - a;
	
	a=0; b=0;
	for(int i=2; i<=n; i+=2)
	{
	    if (i <= y)
		{
			int v = i;
			while(v%2==0)
			{
				a++; v /= 2;
			}
			
		}
		else if (i > x)
		{
			int v = i;
			while(v%2==0)
			{
				b++; v /= 2;
			}
		}
	}
	v2=b-a;
	
	
	printf("[v2: %d, v5: %d]\n", v2, v5);
	//printf("a=%d b=%d\n", a,b);
	return v5;
}
int main()
{
    nCr(25, 12);
}