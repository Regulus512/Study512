#include <stdio.h>

int cnt = 0;
int game(int k, int m, int n)
{
	int s1=0, s2=0;
	while(k--)
	{
		s1 += (s1 < m) ? 1 : 0;
		cnt++;
		if (s1 + k < s2) break;

		s2 += (s2 < n) ? 1 : 0;
		cnt++;
		if (s2 + k < s1) break;
		

	}
	return (s1 == m && s2 == n)? 1 : 0;
}

int main()
{
	int k=1000, n=100000;
	while(n--)
	{
		int m=1000, n=1000;
		game(k, m, n);
	}
	printf("cnt: %d", cnt);
}