#include <stdio.h>

int isPrime(int n)
{
	for (int i = 3; i < n; i++)
	{
		if (n % i == 0) return 0;
	}
	return 1;
}

int main()
{
	while (1)
	{
		int n; scanf_s("%d", &n);
		if (n == 0) break;
		else if (n == 1)
		{
			printf("1\n");
			continue;
		}
		int cnt = 0;
		for (int i = (n % 2 == 0) ? n + 1 : n + 2; i <= 2 * n; i += 2)
		{
			if (isPrime(i))
			{
				//printf("Prime: %d\n", i);
				cnt++;
			}
		}
		printf("%d\n", cnt);
	}
	
}