#include <stdio.h>

int loop = 0;

int main()
{
	int n=1;
	int cnt = 0;
	int p = 2;
	for (; p * p <= 2*n; p++, loop++);
	printf("%d\n", p);
	for(int i=n+1; i<=2*n; i++)
	{
		int res = 1;
		
		for(int j=2; j<p; j++)
		{
			if (i % j == 0)
			{
				loop++;
				printf("%d is not prime\n", i);
				res = 0;
				break;
			}
		}
		cnt += res;
	}
	printf("cnt: %d\n", cnt);
	printf("loop: %d\n", loop);
}