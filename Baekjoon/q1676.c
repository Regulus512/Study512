#include <stdio.h>

int count(int n)
{
	int cnt = 0;
	for(int i=1; i<=n; i++)
	{
		if (i%5==0)   {
			int v = i;
			while(v%5==0)
			{
				cnt+=1; v/=5;
			}
		}
	}
	return cnt;
}

int main()
{
	for(int i = 0; i <= 500; i++)
	{
		printf("%d) = %d\n",i, count(i));
	}
	/*int n; scanf_s("%d", &n);
	printf("%d", count(n));*/
}