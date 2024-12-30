#include <stdio.h>
int main()
{
	int n; scanf_s("%d", &n);

	while (4<=n)
	{
		printf("[N: %d]\n", n);
		int v = n, cnt = 0;
		while (v)
		{
			if(v%10==4 || v%10==7) cnt++;
			else
			{
				cnt = 0;
				break; // ±Ý¹Î¼ö ¾Æ´Ô
			}
			printf("v: %d, count: %d\n", v, cnt);
			v/=10;
		}
		if (cnt > 0)
		{
			printf("%d\n", n);
			return 0;
		}
		n--;
	}
	
}