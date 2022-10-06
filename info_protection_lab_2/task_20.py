from collections import defaultdict
from sys import stdin


graph=defaultdict(list)

n=int(input())

for line in stdin.readlines():
    c1, c2, s = map(int, line.split())
    graph[c1].append(c2)
    graph[c2].append(c1)

visited=[False]*[n]
numbers_of_visits=[]

def number_of_visits(v, parent):
    visited[v]=True
    for i in graph[v]:
        if not visited[i]:
            if number_of_visits(i,v):
                return True
            elif parent != i:
                return True
    return False


def is_cycle():
    n=0
    for i in range(n):
        ++n
        if not visited[i]:
            if number_of_visits(i, -1):
                number_of_visits[i]=n
    return number_of_visits



