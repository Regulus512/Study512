#include <stdio.h>

int cnt = 0; // 최대 얼마나 나오는지 확인

int d(int n)
{
	cnt++;
	int res = n;
	while(n)
	{
		res += n % 10;
		n /= 10;
	}
	return res;
	return res;
}

int main()
{
	int n = 9993;
	printf("%d", d(n));
}