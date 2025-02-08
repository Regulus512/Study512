#include <stdio.h>

int nCr(int n, int r)
{
	int x = (n - r < r) ? r : n-r;
	int y = (n - r < r) ? n-r : r;

	int v2 = 0, v5 = 0;

	for (int i = 5; i <= n; i += 5)
	{
		int cnt = 0;
		if (i <= y)
		{
			//printf("%d: ", i);
			//printf("-");
			int v = i;
			
			while (v % 5 == 0)
			{
				v5--; v /= 5;
				cnt++;
			}
			//printf("%d ", cnt);
		}
		else if (i > x)
		{
			//printf("%d: ", i);
			//printf("+");
			int v = i;
			while (v % 5 == 0)
			{
				v5++; v /= 5;
				cnt++;
			}
			//printf("%d ", cnt);
		}
		
	}
	
	printf("\n");

	for(int i=2; i<=n; i+=2)
	{
		int cnt = 0;
	    if (i <= y)
		{
			int v = i;
			while(v%2==0)
			{
				v2--; v /= 2;
			}
			
		}
		else if (i > x)
		{
			int v = i;
			while(v%2==0)
			{
				v2++; v /= 2;
			}
		}
	}
	//printf("[v2: %d, v5: %d]\n", v2, v5);
	//printf("a=%d b=%d\n", a,b);
	return (v2<v5)? v2 : v5;
}

int div(int a, int b)
{
	int cnt = 0;
	int v = b;

	while (a/v)
	{
		
		cnt += a / v;
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

	//printf("%d %d\n", v2, v5);
	printf("%d\n", (v2 < v5) ? v2 : v5);
	

	
	printf("%d\n", nCr(25, 12));
}
