#include <stdio.h>

int main()
{
	int n; scanf_s("%d", &n);
	int l = n * 4 - 3;
	printf("r*c = %d\n", l);

	for(int i=0; i<l; i++)
	{
		int s = (i<l/2)? i : l - (i+1);
		int e = (i<l/2)? l - (i+1) : i;
		//printf("s: %d, e: %d   ", s, e);

		for(int j=0; j<s; j++)
		{
			printf((j%2==0)?"*" : " ");
		}
		for(int j=s; j<=e; j++)
		{
			printf((i%2==0)? "*" : " ");
		}
		for(int j=e+1; j<l; j++)
		{
			printf((j%2==0)?"*" : " ");
		}

		printf("\n");
	}

}