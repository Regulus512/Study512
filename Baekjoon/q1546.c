#include <stdio.h>

int main()
{
	int n; scanf_s("%d", &n);
	int m = 0; // max
	int sum = 0;
	for(int i = 0; i<n; i++)
	{
		int s;// score
		scanf_s("%d", &s);
		if (m < s) m = s;
		sum += s;
		//printf("%d\n", sum);
	}
	
	printf("%f\n", (float)sum / m * 100 / n);
}