#include <stdio.h>

int isprime(int n)
{
	for(int i = 2; i < n; i++)
	{
		if (n % i == 0) return 0;
	}
	return 1;
}

int main()
{
	int m, n; scanf_s("%d %d", &m, &n);
	if (m == 1) m = 2;
	int min = n, sum = 0;
	for(int i=m; i<=n; i++)
	{
		if (isprime(i))
		{
			printf("%d is prime\n", i);
			sum += i;
			min = (i < min) ? i : min;
		}
	}
	if (sum == 0) printf("-1");
	else printf("%d\n%d", sum, min);
}