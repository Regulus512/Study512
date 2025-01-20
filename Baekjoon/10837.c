#include <stdio.h>

int game(int k, int m, int n)
{
	int s1=0, s2=0;
	while(k--)
	{
		s1 += (s1 < m) ? 1 : 0;
		if (s1 + k < s2) break;
		
		s2 += (s2 < n) ? 1 : 0;
		if (s2 + k < s1) break;
		
	}
	return (s1 == m && s2 == n)? 1 : 0;
}

int main()
{
	int k, n; scanf_s("%d %d", &k, &n);
	while(n--)
	{
		int m, n; scanf_s("%d %d", &m, &n);
		printf("%d\n", game(k, m, n));
	}
}