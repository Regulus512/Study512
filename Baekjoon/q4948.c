#include <stdio.h>

int isPrime(int n)
{
	for(int i = 2; i<n; i++)
	{
		if (n % i == 0) return 0;
	}
	return 1;
}

int Primes(int n)
{
	for(int i = 2; i<n; i++)
	{
		if (isPrime(i))
		{
			if(n%i == 0)
			{
				//printf("%d is divide by %d\n", n, i);
				return 0;
			}
		}
	}
	return 1;
}

int main()
{
	int n = 100;
	int cnt = 0;
	for(int i = n+1; i<=2*n; i++)
	{
		cnt += Primes(i);
	}
	printf("%d\n", cnt);
	
}