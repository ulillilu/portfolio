cache = [[None]*500 for i in range(500)]

def solution(triangle):
    y, x = (0, 0)
    return path(y, x, triangle)

def path(y, x, triangle):
    # base case : 맨 아래줄까지 도달
    if y == len(triangle) - 1: 
        return triangle[y][x]
    # 메모이제이션
    if cache[y][x] != None:
        return cache[y][x]
    # 두 경우 중 합이 더 큰 경우를 선택하여 현재 칸의 값을 더함
    cache[y][x] = max(path(y+1, x, triangle), path(y+1, x+1, triangle)) + triangle[y][x]
    return cache[y][x]