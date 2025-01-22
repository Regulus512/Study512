#include <stdio.h>

int main()
{
	int n; scanf_s("%d", &n);
	int l = n * 4 - 3;
	printf("r*c = %d\n", l);

	for(int i=0; i<l; i++)
	{
		for(int j=0; j<l; j++)
		{
			printf("-");
		}
		printf("\n");
	}

}