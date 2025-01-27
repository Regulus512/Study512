#include <stdio.h>

int main()
{
	int n, t; scanf_s("%d %d", &n, &t);
	int res = 1000000;
	while (n--)
	{
		printf("[%d]\n", n);
		int s, i, c; scanf_s("%d %d %d", &s, &i, &c);
		int b = s;
		for (int a = 1; a <= c; a++, b += i)
		{
			printf("%d 번째 버스 도착 - %d\n", a, b);
			if (t <= b)
			{
				res = (res < b - t) ? res : b - t;
				break;
			}
		}
	}
	if (res != 1000000) printf("%d", res);
	else printf("-1");
}