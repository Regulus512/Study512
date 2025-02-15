#include <stdio.h>

int isPrime(int n)
{
	for (int i = 2; i < n; i++)
	{
		if (n % i == 0) return 0;
	}
	return 1;
}

int some(int n)
{
	for (int v = 2; v < n; v++)
	{
		if (!isPrime(v)) continue;
		//printf("%d\n", v);
		int s = n / v, e = 2 * n / v;
		for (int i = s; i <= e; i++)
		{
			//printf("%d ", i * v);
			if (i * v == n) return 0;
		}
		//printf("\n");
	}
	return 1;
}

int main()
{
	int n=10; //scanf_s("%d", &n);
	//printf("%d\n", some(n));
	int cnt = 0;
	
	for (int i = n + 1; i <= 2 * n; i++)
	{
		if (some(i))
		{
			cnt++;
			//printf("%d\n", i);
		}
	}
	printf("%d\n", cnt);
}