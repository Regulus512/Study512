#include <stdio.h>

int rev(int n)
{
    if (n < 10) return n;
    else if (n < 100) return n % 10 * 10 + n / 10;
    else if (n < 1000) return n % 10 * 100 + n / 10 % 10 * 10 + n / 100;
    else    return n % 10 * 1000 + n / 10 % 10 * 100 + n / 100 % 10 * 10 + n / 1000;

}

int main() {
    int x, y; scanf_s("%d %d", &x, &y);
    if (x > 1000 || y > 1000)
    {
        printf("<error> input can't be > 1000\n");
        return;
    }
    printf("%d+%d = ", rev(x), rev(y));
    printf("%d", rev(rev(x) + rev(y)));
}