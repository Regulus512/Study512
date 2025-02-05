#include<stdio.h>
int nCr(int n, int r)
{
	int x = (n - r < r) ? r : n-r;
	int y = (n - r < r) ? n-r : r;

	int v2 = 0, v5 = 0;
	for(int i=5; i<=n;i+=5)
	{
		if (i < x) continue;

		printf("%d, ", i);
		int v = i;
		while(v%5==0)
		{
			v5++; v /= 5;
		}
	}
	printf(" / ");
	for(int i=5; i<= y; i+=5)
	{
		printf("%d, ", i);
		int v = i;
			while(v%5==0)
			{
				v5--; v /= 5;
			}
	}
	printf("\n");
	printf("%d\n", v5);
	
	x = (x % 2 == 0) ? x : x + 1;
	for(int i=x; i<=n; i+=2)
	{
		printf("%d, ", i);
		int v = i;
		while(v%2==0)
		{
			v2++;
			v /= 2;
		}
	}
	printf(" / ");
	for(int i=2; i<=y; i+=2)
	{
		printf("%d, ", i);
		int v = i;
		while(v%2==0)
		{
			v2--;
			v /= 2;
		}
	}
	printf("\n");
	printf("%d", v2);
	return (v2<v5)? v2 : v5;
}

int main()
{
	nCr(25, 12);
}