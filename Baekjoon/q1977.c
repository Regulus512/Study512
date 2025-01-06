#include <stdio.h>

int main()
{
	int m, n; scanf_s("%d %d", &m, &n);
	int sum=0, min=n;
	for(int i=1;i*i<=n;i++)
	{
		int v = i*i;
		if(m<=v) // m과 n사이의 완전제곱수
		{
			printf("%d^2= %d\n", i, v);
			
			if(v<min) min=v;
			sum+=v;
		}
	}
	if(sum==0) printf("-1");
	else printf("%d\n%d", sum, min);
}