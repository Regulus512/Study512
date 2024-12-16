#include <stdio.h>

int main()
{
	int a, b, c, d, e;
	scanf_s("%d %d %d %d %d", &a, &b, &c, &d, &e);
	int res = 1;

	for (int i = 1; i < 50; i++)
	{
		int count = 0;
		count =
			(a%i==0)+(b%i==0)+(c%i==0)+(d%i==0)+(e%i==0);
		if(count>=3) res *= i;
		printf("[%d] count: %d, res: %d\n", i, count, res);
		count = (res%a==0)+(res%b==0)+(res%c==0)+(res%d==0)+(res%e==0);
		
		if (count >= 3) break;
		
	}
}