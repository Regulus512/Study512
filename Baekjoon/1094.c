#include <stdio.h>

int main()
{
	int x; scanf_s("%d", &x);
	int n = 64, cnt = 1, sum = 0;
	while (n!=x)
	{
		int v=n/2;
		printf("->(%d, %d,%d) ", sum, v, v);
		if (x==sum+v) break;
		else if (x>sum+v)// keep
		{
			printf(" keep");
			cnt++; sum+=v;
		}
		else
		{
			printf("->(%d,0) ", v);
		}
		n=v; // smallest
		printf("\n");
	}
	printf("%d", cnt);
}