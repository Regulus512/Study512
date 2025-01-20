#include <stdio.h>

int game(int k, int m, int n)
{
	int s1=0, s2=0;
	while(k--)
	{
		s1 += (s1 < m) ? 1 : 0;
		printf("left round: %d, score: (%d, %d)\n", k, s1, s2);
		if (s1 + k < s2)
		{
			//printf("s1 lose\n");
			break;
		}
		

		s2 += (s2 < n) ? 1 : 0;
		printf("left round: %d, score: (%d, %d)\n", k, s1, s2);
		if (s2 + k < s1) {
			//printf("s2 lose\n");
			break;
		}
		

	}
	return (s1 == m && s2 == n)? 1 : 0;
}

int main()
{
	int k = 5;
	int m=0, n=2;
	for(int i = 0; i <= k; i++)
	{
		for(int j=0;j<=k;j++)
		{
			printf("[%d, %d] => %d\n", i, j, game(k, i, j));
		}
	}
}