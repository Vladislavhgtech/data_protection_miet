def recursion(n:int):
    if n in (0, 1, 2):
        return 1
    return recursion(n-1)+recursion(n-2)+recursion(n-3)


print(recursion(3))