#include<stdio.h>
int nCr(int n, int r)
{
	int x = (n - r < r) ? r : n-r;
	int y = (n - r < r) ? n-r : r;

	int v2 = 0, v5 = 0;
	for (int i = n; i > x; i--)
	{
		printf("%d ", i);
		int v = i;
		while(v%2==0)
		{
			v /= 2;
			v2++;
		}
		while(v%5==0)
		{
			v /= 5;
			v5++;
		}
	}
	printf("\n");
	for (int i = y; i > 0; i--)
	{
		printf("%d ", i);
		int v = i;
		while(v%2==0)
		{
			v /= 2;
			v2--;
		}
		while(v%5==0)
		{
			v /= 5;
			v5--;
		}
	}
	printf("\n");
	printf("v2)%d v5) %d\n", v2, v5);
	
	return (v2<v5)? v2 : v5;
}

int Count(long long v)
{
	int cnt=0;
	while(v%10==0)
	{
		v /= 10; cnt++;
	}
	return cnt;
}

int main()
{
	printf("%d", nCr(100, 98));

	//int n = 25;
	/*for(int i = 1; i<=n; i++)
	{
		long long res = nCr(n, i);

		printf("'s cnt: %d\n\n", Count(res));
	}*/
		
}