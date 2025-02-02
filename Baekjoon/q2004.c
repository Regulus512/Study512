#include<stdio.h>
long long nCr(int n, int r)
{
	int x = (n - r < r) ? r : n-r;
	int y = (n - r < r) ? n-r : r;
	long long a=1,b=1;
	for (int i = n; i > x; i--)
	{
		printf("%d ", i);
		a *= i;
	}
	printf("\n");
	for (int i = y; i > 0; i--)
	{
		printf("%d ", i);
		b *= i;
	}

	printf("\n%dC%d = %lld/%lld = %lld",n, r, a, b, a/b);
	return a/b;
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
	int n = 25;
	for(int i = 1; i<=n; i++)
	{
		long long res = nCr(n, i);

		printf("'s cnt: %d\n\n", Count(res));
	}
		
}