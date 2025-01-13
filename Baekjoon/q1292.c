#include <stdio.h>

int main()
{
	int a, b; scanf_s("%d %d", &a, &b);
	int cnt = 1, sum = 0;
	for(int i=1; cnt<=1000; i++)
	{
		int v = i;
		while(v--)
		{
			if(a<=cnt)
			{
				//printf("%d: %d\n", cnt, i);
				sum += i;
			}
			if(b==cnt)
			{
				printf("%d", sum); return;
			}
			cnt++;
		}
	}
}