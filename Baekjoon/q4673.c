#include <stdio.h>

int cnt = 0; // �ִ� �󸶳� �������� Ȯ��

int d(int n)
{
	//printf("d(%d)=", n);
	int res = n;
	while(n)
	{
		cnt++;
		res += n % 10;
		n /= 10;
	}
	//printf("%d\n", res);
	return res;
}

int selfnum(int n)
{
	for(int i=1; i<n; i++)
	{
		if(d(i)==n) return 0;
	}
	return 1;
}

int main()
{
	for(int i = 1; i<=10000; i++)
	{
		if (selfnum(i)) printf("%d\n", i);
		//printf("%d) %d\n", i, selfnum(i));
	}
	printf("cnt: %d\n", cnt);
}