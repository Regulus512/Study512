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

int L(int s, int e, int n)
{
	int cnt = 0;
	for(int i=s; i<=e; i++)
	{
		//printf("%d", i);
		if (n > 1)
			cnt += L(i + 1, e, n - 1);
		else
			cnt++;

	}
	//printf("\n");
	return cnt;
}


int main()
{
	int n = 10, r = 3;
	printf("%dC%d=%lld\n", n, r, nCr(n, r));

	printf("%d", L(1, n, r));
	/*
	int cnt = 0;

	int n = 5;
	for(int i=1; i<=n; i++)
	{
		printf("%d", i);
		for(int j=i+1; j<=n; j++)
		{
			
			printf("%d", j);
			cnt++;

		}
		printf("\n");
	}
	printf("%d", cnt);*/
	
}