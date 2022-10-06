def sort_list(N:int, list):
    if (N==len(list) and N<=1000):
        list=sorted(list)
        print(*list, sep=' ')



if __name__ == "__main__":
    N=5
    list=[2.3, 17.7, 17.8, -4.12, 35.0]

    sort_list(N, list)