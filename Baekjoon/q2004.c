#include <stdio.h>

int div(int a, int b)
{
	int cnt = 0;
	long long v = b;

	while (a/v)
	{
		cnt += a / v;
		//printf("cnt: %d v: %lld\n", cnt, v);
		v *= b;
	}
	//printf("div(%d, %d)=%d\n", a,b,cnt);
	return cnt;
}

int main()
{
	
	int v2 = 0, v5 = 0;
	int n = 25, r = 12;
	
	v2 = div(n, 2) - div(r, 2) - div(n - r, 2);
	v5 = div(n, 5) - div(r, 5) - div(n - r, 5);

	printf("[v2: %d v5: %d]\n", v2, v5);
	printf("%d\n", (v2 < v5) ? v2 : v5);
}
