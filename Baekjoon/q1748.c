#include <stdio.h>

int main()
{
	int n = 100000000;
	int res = 0;
	int i = 0, v = 1;
	while (v*10<=n)
	{
		i++;
		v *= 10;
	}
	//printf("%d : (i)%d (v)%d\n", n, i, v);


	while (v)
	{
		if (v == 1)
		{
			res += n;
		}
		else
		{
			res += (n - v + 1)*(i+1);
		}
		printf("%d) n: %d, res: %d\n", i, n, res);
		n = n / n * v - 1;
		i--; v /= 10;
	}
	//printf("res: %d\n", res);
}